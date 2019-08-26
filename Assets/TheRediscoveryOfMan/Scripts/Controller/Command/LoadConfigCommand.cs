using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaFramework;
using System.IO;
using System;
using System.Xml;
using UnityEngine.Networking;
public class LoadConfigCommand : ControllerCommand {

    public override void Execute(IMessage message) {
        //加载配置文件
        LoadSetting();
	}
    
    private IEnumerator LoadSetting()
    {
        string path = AppConst.SettingPath;
        Util.Log("Load Setting File...\n" + path);

        byte[] bytes = null;
        if (path.Contains("://"))
        {
            UnityWebRequest request = UnityWebRequest.Get(path);
            yield return request.Send();
            if (request.isNetworkError || request.isHttpError)
            {
                Util.Log("Failed to Load Setting Xml: " + path + "\n" + request.error);
                request.Dispose();
                yield break;
            }
            bytes = request.downloadHandler.data;
            request.Dispose();
        }
        else
        {
            try 
            {
                bytes = File.ReadAllBytes(path);
            }
            catch (Exception e)
            {
                Util.Log("Failed to Load Setting Xml: " + path + "\n" + e.Message);
                yield break;
            }
        }
        ReadSetting(bytes);
    }

    private void ReadSetting(byte[] bytes)
    {
        Util.Log("Read Setting File...");
        MemoryStream stream = new MemoryStream(bytes);
        XmlTextReader reader = new XmlTextReader(stream);
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "setting")
            {
                AppConst.AppVersion     = reader.GetAttribute("version");
                AppConst.ConfigURI      = reader.GetAttribute("server");
                AppConst.AppIdentifer   = reader.GetAttribute("appid");
                AppConst.AppChannel     = reader.GetAttribute("channel");
            }
        }
        reader.Close();
        stream.Close();
    }
}
