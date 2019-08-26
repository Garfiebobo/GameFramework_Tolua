using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Xml;
/// <summary>
/// </summary>
public class Main : MonoBehaviour
{
    void Start()
    {

    }

    private void SetSetting()
    {
#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
        Screen.SetResolution(506, 900, false);
#endif
        //设置游戏配置
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = AppConst.GameFrameRate;
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
                AppConst.ConfigURI      = reader.GetAttribute("config");
                AppConst.AppIdentifer   = reader.GetAttribute("identifer");
                AppConst.AppChannel     = reader.GetAttribute("channel");
            }
        }
        reader.Close();
        stream.Close();
    }

    //启动游戏
    private void StartUp()
    {
        AppFacade.Instance.StartUp();   //启动游戏
    }
}
