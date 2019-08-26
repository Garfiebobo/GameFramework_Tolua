﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class AppConstWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AppConst), typeof(System.Object));
		L.RegFunction("New", _CreateAppConst);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("OS", get_OS, set_OS);
		L.RegConstant("DebugMode", 0);
		L.RegConstant("ExampleMode", 1);
		L.RegConstant("UpdateMode", 0);
		L.RegVar("UserId", get_UserId, set_UserId);
		L.RegConstant("LuaByteMode", 0);
		L.RegConstant("LuaBundleMode", 1);
		L.RegConstant("TimerInterval", 1);
		L.RegConstant("GameFrameRate", 30);
		L.RegVar("AppName", get_AppName, null);
		L.RegVar("LuaTempDir", get_LuaTempDir, null);
		L.RegVar("AppPrefix", get_AppPrefix, null);
		L.RegVar("ExtName", get_ExtName, null);
		L.RegVar("AssetDir", get_AssetDir, null);
		L.RegVar("WebUrl", get_WebUrl, null);
		L.RegVar("VerionName", get_VerionName, null);
		L.RegVar("PatchName", get_PatchName, null);
		L.RegVar("PatchAsset", get_PatchAsset, null);
		L.RegVar("AssetRoot", get_AssetRoot, null);
		L.RegVar("ConfigURI", get_ConfigURI, set_ConfigURI);
		L.RegVar("AssetURI", get_AssetURI, set_AssetURI);
		L.RegVar("AppVersion", get_AppVersion, set_AppVersion);
		L.RegVar("AppIdentifer", get_AppIdentifer, set_AppIdentifer);
		L.RegVar("AppChannel", get_AppChannel, set_AppChannel);
		L.RegVar("IsVerify", get_IsVerify, set_IsVerify);
		L.RegVar("SocketPort", get_SocketPort, set_SocketPort);
		L.RegVar("SocketAddress", get_SocketAddress, set_SocketAddress);
		L.RegVar("ABNAME", get_ABNAME, set_ABNAME);
		L.RegVar("ConfigPath", get_ConfigPath, null);
		L.RegVar("AssetPath", get_AssetPath, null);
		L.RegVar("FrameworkRoot", get_FrameworkRoot, null);
		L.RegVar("SettingPath", get_SettingPath, null);
		L.RegVar("ABZipPath", get_ABZipPath, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAppConst(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				AppConst obj = new AppConst();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: AppConst.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OS(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.OS);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UserId(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.UserId);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.AppName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaTempDir(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.LuaTempDir);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppPrefix(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.AppPrefix);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ExtName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.ExtName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetDir(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.AssetDir);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WebUrl(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.WebUrl);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_VerionName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.VerionName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PatchName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.PatchName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PatchAsset(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.PatchAsset);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetRoot(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.AssetRoot);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ConfigURI(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.ConfigURI);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetURI(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.AssetURI);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppVersion(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.AppVersion);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppIdentifer(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.AppIdentifer);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppChannel(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.AppChannel);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsVerify(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, AppConst.IsVerify);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketPort(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, AppConst.SocketPort);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketAddress(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.SocketAddress);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ABNAME(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.ABNAME);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ConfigPath(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.ConfigPath);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetPath(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.AssetPath);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FrameworkRoot(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.FrameworkRoot);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SettingPath(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.SettingPath);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ABZipPath(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, AppConst.ABZipPath);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OS(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			AppConst.OS = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UserId(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			AppConst.UserId = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ConfigURI(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			AppConst.ConfigURI = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AssetURI(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			AppConst.AssetURI = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AppVersion(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			AppConst.AppVersion = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AppIdentifer(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			AppConst.AppIdentifer = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AppChannel(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			AppConst.AppChannel = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsVerify(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			AppConst.IsVerify = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SocketPort(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			AppConst.SocketPort = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SocketAddress(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			AppConst.SocketAddress = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ABNAME(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			AppConst.ABNAME = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

