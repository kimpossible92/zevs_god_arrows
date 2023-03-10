using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Wizcorp.Web
{
	public class WebView : MonoBehaviour
	{
		public string URL = "";
		public Text Context;

		#region shared
		public void CallBack(string message)
		{
			Context.text = message;
		}
		#endregion

#if UNITY_ANDROID
		public void CallWebView()
		{
			Debug.Log("Call WebView");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			currentActivity.Call("OpenWebView", URL);
		}

		void Start()
		{
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			currentActivity.Call("SetupCallBack", this.gameObject.name, "CallBack", "Calling back from Android");
			CallWebView();
		}
#endif

	}
}