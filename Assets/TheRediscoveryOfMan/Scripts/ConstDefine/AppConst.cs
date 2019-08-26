using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AppConst
{
#if UNITY_STANDALONE
    public static string OS = "pc";
#elif UNITY_ANDROID
        public static string OS = "android";
#elif UNITY_IOS
        public static string OS = "ios";
#else
        public static string OS = "temp";
#endif
    public const bool DebugMode = false;                       //调试模式-用于内部测试
    public const bool ExampleMode = true;                       //例子模式 

    /// <summary>
    /// 如果开启更新模式，前提必须启动框架自带服务器端。
    /// 否则就需要自己将StreamingAssets里面的所有内容
    /// 复制到自己的Webserver上面，并修改下面的WebUrl。
    /// </summary>
#if UNITY_EDITOR
        public const bool UpdateMode = false;                                //更新模式-默认关闭 
#else
        public const bool UpdateMode = false;                                 //更新模式-默认关闭 
#endif

    public static string UserId = string.Empty;                 //用户ID

    public const bool LuaByteMode = false;                      //Lua字节码模式-默认关闭 
    public const bool LuaBundleMode = true;                   //Lua代码AssetBundle模式
    public const int  TimerInterval = 1;
    public const int  GameFrameRate = 30;                         //游戏帧频
    public const string AppName = "TheRediscoveryOfMan";        //应用程序名称
    public const string LuaTempDir = "Lua/";                     //临时目录
    public const string AppPrefix = AppName + "_";               //应用程序前缀
    public const string ExtName = ".unity3d";                    //素材扩展名
    public const string AssetDir = "StreamingAssets";            //素材目录 

    public const string WebUrl = "http://localhost:6688/";         //测试更新地址

    public const string VerionName = "version.txt";                      //版本管理文件名
    public const string PatchName = "pversion.txt";                      //补丁管理文件名
    public const string PatchAsset = "patch.ab";                         //补丁包名
    public const string AssetRoot = "Assets/TheRediscoveryOfMan/Assets/";   //素材路径

    public static string ConfigURI = "";                                 //配置文件地址，setting.xml读取覆盖
    public static string AssetURI = "";                                  //资源更新地址，config.txt读取覆盖
    public static string AppVersion = "";                                //游戏版本号，setting.xml读取覆盖
    public static string AppIdentifer ="";                               //APP  bundle  ID
    public static string AppChannel ="";                                 //渠道标识
    public static bool   IsVerify = false;                               //是否提审
    public static int    SocketPort = 0;                                 //Socket服务器端口
    public static string SocketAddress = string.Empty;                   //Socket服务器地址

    public static string ABNAME ="First";
    public static string ConfigPath
    {
        get { return ConfigURI + AppVersion + "/config.txt"; }    // 配置文件地址 + 版本号
    }

    public static string AssetPath
    {
        get { return AssetURI + OS + "/"; }                       // 资源地址
    }

    public static string FrameworkRoot
    {
        get
        {
            return Application.dataPath + "/" + AppName;
        }
    }
    
    //setting  配置
     public static string SettingPath
    {
        get { return Application.streamingAssetsPath + "/SettingConfig.xml"; }
    }
    
    //资源包 配置
    public static string ABZipPath
    {
        get { return Application.streamingAssetsPath + "/" + ABNAME; }
    }
 
}
