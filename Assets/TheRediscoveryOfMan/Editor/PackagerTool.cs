using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Diagnostics;
using System.Xml;

public class PackagerTool : ScriptableObject
{

    public static string ASSETS_CONFIG_PATH = "Assets/TheRediscoveryOfMan/Editor/Config/AssetConfig.txt"; // 资源配置路径
    public static string PATCH_CONFIG_PATH = "Assets/TheRediscoveryOfMan/Editor/Config/PatchConfig.txt"; // 补丁配置路径
    public static string LUA_CONFIG_PATH = "Assets/TheRediscoveryOfMan/Editor/Config/LuaConfig.txt";         //Lua配置路径


    public static string AB_EXTENSION = ".ab";
    public static string AB_MANIFESET = "index" + AB_EXTENSION;
    // make the lua file bytes  mode:0 不用byte  32 luajit32  64 luajit 64
    private static void LuaByteFiles(string path, string root, int mode = 0)
    {
        string[] files = Directory.GetFiles(path, "*.lua", SearchOption.AllDirectories);
        for (int i = 0; i < files.Length; i++)
        {
            string src = files[i].Replace("\\", "/");
            string dest = root + src.Replace(path, "") + ".bytes";
            string dir = Path.GetDirectoryName(dest);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (Application.platform == RuntimePlatform.WindowsEditor)
                WinEncodeLuaFile(src, dest, mode);
            else if (Application.platform == RuntimePlatform.OSXEditor)
                MacEncodeLuaFile(src, dest, mode);
        }
    }

    // mac os decode lua file
    private static void MacEncodeLuaFile(string srcFile, string destFile, int mode)
    {
        if (mode == 0)
        {
            File.Copy(srcFile, destFile, true);
            return;
        }

        string currDir = Directory.GetCurrentDirectory();
        Directory.SetCurrentDirectory("LuaEncoder/luavm/");
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = "./luac";
        info.Arguments = "-o ../../" + srcFile + " ../../" + destFile;
        info.WindowStyle = ProcessWindowStyle.Hidden;
        info.ErrorDialog = true;
        info.UseShellExecute = false;

        Process pro = Process.Start(info);
        pro.WaitForExit();
        Directory.SetCurrentDirectory(currDir);
    }

    // win os decode lua file
    private static void WinEncodeLuaFile(string srcFile, string destFile, int mode)
    {
        if (mode == 0)
        {
            File.Copy(srcFile, destFile, true);
            return;
        }

        string currDir = Directory.GetCurrentDirectory();
        Directory.SetCurrentDirectory("LuaEncoder/luajit" + mode + "/");
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = "luajit.exe";
        info.Arguments = "-b ../../" + srcFile + " ../../" + destFile;
        info.WindowStyle = ProcessWindowStyle.Hidden;
        info.ErrorDialog = true;
        info.UseShellExecute = true;

        Process pro = Process.Start(info);
        pro.WaitForExit();
        Directory.SetCurrentDirectory(currDir);
    }

    // build version file
    private static void BuildVersionFile(string path, string output, Dictionary<string, bool> patch, List<AssetBundleBuild> buildmap)
    {
        string content = string.Empty;
        for (int i = 0; i < buildmap.Count; i++)
        {
            string abname = buildmap[i].assetBundleName;
            if (patch.ContainsKey(abname)) //is patch version control
                continue;

            if (content != string.Empty) content += "\n";
            string filename = output + abname;
            content += abname + "|" + Util.md5file(filename) + "|" + Util.filesize(filename);
        }
        File.WriteAllText(path, content);
    }

    //compare    ab 
    private static void CompareManifestFile(AssetBundleManifest last, AssetBundleManifest now)
    {
        if (last == null || now == null)
            return;

        List<string> abnames1 = new List<string>(last.GetAllAssetBundles());
        List<string> abnames2 = new List<string>(now.GetAllAssetBundles());
        for (int i = 0; i < abnames1.Count; i++)
        {
            if (abnames2.IndexOf(abnames1[i]) == -1) //delete
                UnityEngine.Debug.Log("Delete AssetBundle: " + abnames1[i]);
        }
        for (int i = 0; i < abnames2.Count; i++)
        {
            if (abnames1.IndexOf(abnames2[i]) == -1) //add
            {
                UnityEngine.Debug.Log("Add AssetBundle: " + abnames2[i]);
                continue;
            }

            //check change
            Hash128 hash1 = last.GetAssetBundleHash(abnames2[i]);
            Hash128 hash2 = now.GetAssetBundleHash(abnames2[i]);
            if (!hash1.Equals(hash2))
                UnityEngine.Debug.Log("Change AssetBundle: " + abnames2[i]);
        }
    }

    // build asset config
    private static void BuildAssetConfig(string path, List<AssetBundleBuild> buildmap)
    {
        string abname = Path.GetFileNameWithoutExtension(path).ToLower();
        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = abname + AB_EXTENSION;
        build.assetNames = new string[] { path };
        buildmap.Add(build);
    }


    // build lua config
    private static void BuildLuaConfig(string path, List<AssetBundleBuild> buildmap)
    {
        string content = string.Empty;
        for (int i = 0; i < buildmap.Count; i++)
        {
            if (!buildmap[i].assetBundleName.StartsWith("lua"))
                continue;

            if (content != string.Empty) content += "\n";
            content += buildmap[i].assetBundleName;
        }
        File.WriteAllText(path, content);

        //add to build
        string abname = Path.GetFileNameWithoutExtension(path).ToLower();
        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = abname + AB_EXTENSION;
        build.assetNames = new string[] { path };
        buildmap.Add(build);
    }


    // build patch version file
    private static void BuildPatchFile(string path, string output, Dictionary<string, bool> patch, List<AssetBundleBuild> buildmap)
    {
        string content = string.Empty;
        for (int i = 0; i < buildmap.Count; i++)
        {
            string abname = buildmap[i].assetBundleName;
            if (!patch.ContainsKey(abname)) //not patch version control
                continue;

            if (content != string.Empty) content += "\n";
            content += abname + "|" + Util.md5file(output + abname);
        }
        File.WriteAllText(path, content);
    }


    [MenuItem("RediscoveryOfMan/Build AssetBundles", false, 100)]
    public static List<AssetBundleBuild> PackAssetBundles()
    {
        if (!EditorUtility.DisplayDialog("", "Package the assetbundles?", "Yes", "No"))
            return null;

        if (EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("", "Script is compiling, try again later.", "Yes");
            return null;
        }

        //encode lua files
        PackagerTool.EncodeLuaJIT32Files();
        PackagerTool.EncodeLuaJIT64Files();

        //read config
        Dictionary<string, int> config = new Dictionary<string, int>();
        string[] lines = File.ReadAllLines(ASSETS_CONFIG_PATH);
        for (int i = 0; i < lines.Length; i++)
        {
            //路径 | 打包方式(1:文件夹打包成一个AB, 2:文件打成一个AB, 3:文件夹里的文件夹打成一个AB)
            string[] line = lines[i].Split('|');
            config.Add(line[0], int.Parse(line[1]));
        }

        //read patch
        Dictionary<string, bool> patch = new Dictionary<string, bool>();
        lines = File.ReadAllLines(PATCH_CONFIG_PATH);
        for (int i = 0; i < lines.Length; i++)
        {
            //补丁包, assetbundle名称索引
            if (lines[i] != string.Empty)
                patch.Add(lines[i], true);
        }

        //make build map
        List<AssetBundleBuild> buildmap = new List<AssetBundleBuild>();
        foreach (var pair in config)
        {
            string mname = "DoMakeAssetBundleBuild" + pair.Value;
            MethodInfo method = typeof(PackagerTool).GetMethod(mname, BindingFlags.Static | BindingFlags.Public);
            if (method == null) continue;
            string src = AppConst.AssetRoot + pair.Key;
            object builds = method.Invoke(null, new object[] { src });
            buildmap.AddRange(builds as IEnumerable<AssetBundleBuild>);
        }

        if (!Directory.Exists(AppConst.OUTPUT_ROOT)) Directory.CreateDirectory(AppConst.OUTPUT_ROOT);
        PackagerTool.BuildAssetConfig(ASSETS_CONFIG_PATH, buildmap);
        PackagerTool.BuildLuaConfig(LUA_CONFIG_PATH, buildmap);
        AssetDatabase.Refresh();

        //build assetbundles
        string outputName = Path.GetDirectoryName(AppConst.OUTPUT_ROOT);
        string manifestPath = AppConst.OUTPUT_ROOT + Path.GetFileName(outputName);
        AssetBundleManifest last = null;
        if (File.Exists(manifestPath))
        {
            AssetBundle ab = AssetBundle.LoadFromFile(manifestPath);
            last = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            ab.Unload(false);
        }

        AssetBundleManifest now = BuildPipeline.BuildAssetBundles(AppConst.OUTPUT_ROOT, buildmap.ToArray(),
        BuildAssetBundleOptions.ChunkBasedCompression,
        EditorUserBuildSettings.activeBuildTarget);

        //copy now manifest file
        FileInfo fileInfo = new FileInfo(manifestPath);
        fileInfo.CopyTo(AppConst.OUTPUT_ROOT + AB_MANIFESET, true);

        //add manifest to version control
        AssetBundleBuild abb = new AssetBundleBuild();
        abb.assetBundleName = AB_MANIFESET;
        buildmap.Add(abb);

        //build version file
        PackagerTool.CompareManifestFile(last, now);
        PackagerTool.BuildVersionFile(AppConst.VersionRoot, AppConst.OUTPUT_ROOT, patch, buildmap);
        PackagerTool.BuildPatchFile(AppConst.PatchRoot, AppConst.OUTPUT_ROOT, patch, buildmap);

        AssetDatabase.Refresh();
        UnityEngine.Debug.Log("Build assetbundles files finish!!");
        return buildmap;
    }

    [MenuItem("RediscoveryOfMan/Encode Lua Files(LuaJIT64)", false, 92)]
    public static void EncodeLuaJIT64Files()
    {
        //if (!EditorUtility.DisplayDialog("", "Encode LuaJIT64 Lua Files?", "Yes", "No"))
        //    return;

        LuaByteFiles(AppConst.LuaRoot, AppConst.LuaRoot + "64/", 64);
        LuaByteFiles(AppConst.ToluaRoot + "/Lua", AppConst.LuaRoot + "64/", 64);

        AssetDatabase.Refresh();
        UnityEngine.Debug.Log("Encode LuaJIT64 lua files finish!!");
    }

    [MenuItem("RediscoveryOfMan/Encode Lua Files(LuaJIT32)", false, 91)]
    public static void EncodeLuaJIT32Files()
    {
        //if (!EditorUtility.DisplayDialog("", "Encode LuaJIT32 Lua Files?", "Yes", "No"))
        //    return;

        LuaByteFiles(AppConst.LuaRoot, AppConst.LuaRoot + "32/", 32);
        LuaByteFiles(AppConst.ToluaRoot + "/Lua", AppConst.LuaRoot + "32/", 32);

        AssetDatabase.Refresh();
        UnityEngine.Debug.Log("Encode LuaJIT32 lua files finish!!");
    }

}