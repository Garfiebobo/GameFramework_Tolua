using System;
using System.Collections.Generic;

public static class GameConfig
{
    private static Dictionary<string, string> configs = new Dictionary<string, string>();
    public static void Set(string _line)
    {
        Set(_line.Split('\n'));
    }

    public static void Set(string[] _line)
    {
        for (int i = 0; i < _line.Length; i++)
        {
            string _one = _line[i].Trim();
            _one = _one.Replace(" ", string.Empty);
            string[] _oneLine = _one.Split('=');
            if (_oneLine.Length < 2) continue;
            if (configs.ContainsKey(_oneLine[0]))
            {
                configs[_oneLine[0]] = _oneLine[1];
            }
            else
            {
                configs.Add(_oneLine[0], _oneLine[1]);
            }
        }
    }

    public static void Add(string _key, string _value)
    {
        if (configs.ContainsKey(_key))
        {
            configs[_key] = _value;
        }
        else
        {
            configs.Add(_key, _value);
        }
    }
    public static void Add(string _key, double _value)
    {
        Add(_key, _value.ToString());
    }
    public static void Add(string _key, bool _value)
    {
        Add(_key, _value.ToString());
    }

    private static string TryGet(string _key)
    {
        if (configs.ContainsKey(_key))
        {
            return configs[_key];
        }
        return string.Empty;
    }
    public static string Get(string _key)
    {
        return TryGet(_key);
    }
    public static int GetInt(string _key)
    {
        int _out = 0;
        int.TryParse(TryGet(_key), out _out);
        return _out;
    }
    public static float GetFloat(string _key)
    {
        float _out = 0f;
        float.TryParse(TryGet(_key), out _out);
        return _out;
    }
    public static bool GetBool(string _key)
    {
        string _value = TryGet(_key).ToLower();
        if (string.IsNullOrEmpty(_value))
        {
            return false;
        }
        if (_value.Equals("false") || _value.Equals("no") || _value.Equals("null") || _value.Equals("nil"))
        {
            return false;
        }
        return true;
    }
}
