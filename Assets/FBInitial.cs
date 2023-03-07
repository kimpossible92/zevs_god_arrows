using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System;
using UnityEngine.UI;
//using FantomLib;
public class LNKRes : IAppLinkResult
{
    public string Url => _url;
    private string _url;
    public void seturl(string _urls) { _url = _urls; }
    public string TargetUrl => throw new NotImplementedException();

    public string Ref => throw new NotImplementedException();

    public IDictionary<string, object> Extras => throw new NotImplementedException();

    public string Error => throw new NotImplementedException();

    public IDictionary<string, string> ErrorDictionary => throw new NotImplementedException();

    public IDictionary<string, object> ResultDictionary => throw new NotImplementedException();

    public string RawResult => rwresult;
    private string rwresult;
    public void setrwres(string res) { rwresult = res; }
    public bool Cancelled => throw new NotImplementedException();
}
public class FBInitial : MonoBehaviour
{
    //public static FBInitial facebook;
    public Text deeplink;
    [SerializeField] string[] subs;

    public ScriptableString url;

    private void Awake()
    {
        viewLinks(url.value);
        DontDestroyOnLoad(this);
    }
    public void viewLinks(string link)
    {
        url.value = link;
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallback, OnHideUnity);
            //FB.Mobile.FetchDeferredAppLinkData(DeepLinkCallback);
            Debug.Log("awake not init");
        }
        else
        {
            FB.ActivateApp();
            FB.Mobile.FetchDeferredAppLinkData(DeepLinkCallback);
            Debug.Log("awake active app");
        }

       
    }
    private void Start()
    {
        //FB.LogAppEvent("starting");
        AppsFlyerSDK.AppsFlyer.sendEvent("starting", null);
        Invoke("DestroyParent", 8f);
    }
    [SerializeField] GameObject parent1;
    private void DestroyParent()
    {
        parent1.SetActive(false);
    }
    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            Debug.Log("FB is initialized unit call");
            FB.Mobile.FetchDeferredAppLinkData(DeepLinkCallback);
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void FacebookEvent()
    {
        var samplParams = new Dictionary<string, object>();
        samplParams[AppEventParameterName.ContentID] = "sample_step_1";
        samplParams[AppEventParameterName.Description] = "First step, clicking the first button!";
        samplParams[AppEventParameterName.Success] = "1";

        FB.LogAppEvent(
           AppEventName.CompletedTutorial,
           parameters: samplParams
        );
    }

    void DeepLinkCallback(IAppLinkResult result)
    {
        DeepLNK(result);
        FindObjectOfType<UniWebView>().setUri("sub_id_1="+FB.AppId+ "&sub_id_2=2222&sub_id_3=3333");
    }
    void DeepLNK(IAppLinkResult result)
    {
        LNKRes newresult = new LNKRes();
        newresult.seturl(url.value);
        result = newresult;
        if (!String.IsNullOrEmpty(result.Url))
        {
            Debug.Log("scriptable " + url.value);
            deeplink.text += result.Url;
            Debug.Log(deeplink.text);
            var index = (new Uri(result.Url)).Query.IndexOf("request_ids");
            if (index != -1)
            {
                //FindObjectOfType<UniWebView>().Load(result.Url);
            }
        }
    }
}
