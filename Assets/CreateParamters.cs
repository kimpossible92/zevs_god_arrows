using FantomLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class AccountData
{
    public string userId;
    public string country;
    public string url1;
    public bool isFirstOpen = true;
}
public class AppsflyerKey
{
    public const string AfFirstOpen = "af_first_open";
    public const string AfAdComplete = "af_ad_complete";
    public const string AfPurchase = "af_purchase";
    public const string AfCompleteTut = "af_complete_tut";
    public const string AfCompleteStage = "af_complete_stage_{0}";
}
public class CreateParamters : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    public bool shouldAnonymizeUser = false;
    public UnityEngine.UI.Button anonymizeUserBTN;
    [SerializeField]
    private UnityEngine.UI.Text _textState;
    public string sampleUrl1 = "sample.html";
    public string sampleUrl2 = "";
    [SerializeField] GameObject sampleGo_s;
    [SerializeField] GameObject PlayBtn;
    [SerializeField] string[] turkeybrazilitaly = { "Turkey", "Brazil", "Italy" };
    public bool usenewRealUrl1;
    [SerializeField] bool hanler2_s=false;
    [SerializeField] public int iswebview = 0;
    string samplestr = "";
    public AccountData account;
    public void OpenAppsStats()
    {
        AndroidPlugin.StartOpenURL("https://extreme-ip-lookup.com/json/63.70.164.200?key=GsLo3KJXIPiZydbnHXyO");
        AndroidPlugin.StartOpenURL("https://pin-up.casino/?lang=lang&st=NcrpBhP5&s1=308c7bv1eg&s2=&s3=&s4=&s5=&source=&pc=30&options={options}&form_key={_form_key}&trId=cf98rn1ct2h7v8m0nuag&popup=openregistration2step");
    }
    void Start()
    {
        iswebview = 0;
        account = new AccountData();
        sampleGo_s.SetActive(false);
        PlayBtn.SetActive(false);
        AppsFlyerSDK.AppsFlyer.anonymizeUser(true);
        //button.onClick.AddListener(Handler);
        if (hanler2_s) {
            account.isFirstOpen = PlayerPrefs.GetInt("firstopen2") == 0;
            if (PlayerPrefs.GetInt("firstopen2") == 0)
            {
                Handler2();
            }
            else if (PlayerPrefs.GetInt("firstopen2") == 1)
            {
                sampleUrl1 = PlayerPrefs.GetString("realurl2");
                print(PlayerPrefs.GetString("realurl2"));
                StartCoroutine(GetRedirectProverka1());
                //sampleGo_s.SetActive(true);
                //PlayBtn.SetActive(true);
            }
            else
            {
                sampleUrl1 = PlayerPrefs.GetString("realurl2");
                StartCoroutine(GetRedirectProverka1());
                //sampleGo_s.SetActive(true);
                //PlayBtn.SetActive(true);
            }
        }
        else
        {
            account.isFirstOpen = PlayerPrefs.GetInt("firstopen") == 0;
            if (PlayerPrefs.GetInt("firstopen") == 0)
            {
                //if (hanler2_s) { Handler2(); }
                //else { 
                Handler();
                //}
            }
            else if (PlayerPrefs.GetInt("firstopen") == 1)
            {
                sampleUrl1 = PlayerPrefs.GetString("realurl");
                print(PlayerPrefs.GetString("realurl"));
                StartCoroutine(GetRedirectProverka());
                //sampleGo_s.SetActive(true);
                //PlayBtn.SetActive(true);
            }
            else
            {
                sampleUrl1 = PlayerPrefs.GetString("realurl");
                StartCoroutine(GetRedirectProverka());
                //sampleGo_s.SetActive(true);
                //PlayBtn.SetActive(true);
            }
        }
    }
    public void anonymizeUser()
    {
        shouldAnonymizeUser = !shouldAnonymizeUser;
        AppsFlyerSDK.AppsFlyer.anonymizeUser(shouldAnonymizeUser);
        anonymizeUserBTN.GetComponentInChildren<UnityEngine.UI.Text>().text = !shouldAnonymizeUser ? "Anonymize User" : "Deanonymize User";
    }
    IEnumerator GetRedirectProverka1()
    {
        var sampleUrl = "https://conversionleadstraffic.info/dv5RmK?sub_id_1=1716811392082384" + "&sub_id_2=Russia" + "&sub_id_3=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId();
        UnityWebRequest request1 = UnityWebRequest.Get(sampleUrl);
        var rqwst2 = request1.SendWebRequest();
        yield return rqwst2;
        if(request1.isNetworkError||request1.url == sampleUrl)
        {
            iswebview = 1;
            sampleGo_s.SetActive(false);
            PlayBtn.SetActive(true);
        }
        else if (request1.url == PlayerPrefs.GetString("realurl2"))
        {
            iswebview = 2;
            sampleGo_s.SetActive(true);
            PlayBtn.SetActive(true);print("old"+request1.url);
        }
        else
        {
            iswebview = 2;
            PlayerPrefs.SetString("realurl2", request1.url);
            sampleGo_s.SetActive(true);
            PlayBtn.SetActive(true); print("update" + request1.url);
        }
    }
    IEnumerator GetRedirectProverka()
    {
        var sampleUrl = "https://topoffer2.online/VtQBjp" + "?sub_id_1=1716811392082384" + "&sub_id_2=country" + "&sub_id_3=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId();
        UnityWebRequest request1 = UnityWebRequest.Get(sampleUrl);
        var rqwst2 = request1.SendWebRequest();
        yield return rqwst2;
        if (request1.isNetworkError || request1.url == sampleUrl)
        {
            iswebview = 1;
            sampleGo_s.SetActive(false);
            PlayBtn.SetActive(true);
        }
        else if (request1.url == PlayerPrefs.GetString("realurl"))
        {
            iswebview = 2;
            sampleGo_s.SetActive(true);
            PlayBtn.SetActive(true);
        }
        else
        {
            iswebview = 2;
            PlayerPrefs.SetString("realurl", request1.url);
            sampleUrl1 = PlayerPrefs.GetString("realurl");
            sampleGo_s.SetActive(true);
            PlayBtn.SetActive(true);
        }
    }
    public void Handler2()
    {
        StartCoroutine(createAnotherParams());
    }
    private void Handler()
    {
        if (!usenewRealUrl1) { StartCoroutine(CreateParams()); }
        else { StartCoroutine(createNewParams()); }
    }
    IEnumerator createAnotherParams()
    {
        sampleUrl1 = "https://conversionleadstraffic.info/dv5RmK?sub_id_1=1716811392082384" + "&sub_id_2=Russia"+ "&sub_id_3=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId();
        UnityWebRequest request1 = UnityWebRequest.Get(sampleUrl1);
        var rqwst2 = request1.SendWebRequest();
        yield return rqwst2;
        print(request1.url);
        if (request1.isNetworkError || request1.url == sampleUrl1)
        {
            iswebview = 1;
            _textState.text = "error : " + request1.error;
            PlayerPrefs.SetInt("firstopen2", 0);
            PlayerPrefs.SetString("realurl2", request1.url); 
            sampleGo_s.SetActive(false);
            PlayBtn.SetActive(true);
            
        }
        else
        {
            if (rqwst2.isDone)
            {
                iswebview = 2;
                _textState.text = request1.downloadHandler.text;
                print(request1.downloadHandler.text);
                PlayerPrefs.SetInt("firstopen2", 1);
                PlayerPrefs.SetString("realurl2", request1.url);
                sampleGo_s.SetActive(true);
                PlayBtn.SetActive(true);
                var eventValues = new Dictionary<string, string>();
                AppsFlyerSDK.AppsFlyer.sendEvent("webview-started", eventValues);
            }
        }
    }
    IEnumerator createNewParams()
    {
        sampleUrl1 = "https://topoffer2.online/VtQBjp" + "?sub_id_1=1716811392082384" + "&sub_id_2=country" + "&sub_id_3=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId();
        UnityWebRequest request12 = UnityWebRequest.Get(sampleUrl1);
        var rqwst2 = request12.SendWebRequest();
        yield return rqwst2;
        print(request12.url);
        account.url1=request12.url;
        account.userId = AppsFlyerSDK.AppsFlyer.getAppsFlyerId();
        //samplestr = request12.downloadHandler.
        if (request12.isNetworkError|| request12.url==sampleUrl1 || request12.url == "https://www.privacypolicyonline.com/live.php?token=M7zWyBMdQVDjhzAWIahoxwrKayuhvM6j") {
            iswebview = 1;
            _textState.text = "error : " + request12.error;
            sampleGo_s.SetActive(false);
            print(request12.downloadHandler.text);
            PlayBtn.SetActive(true);
            PlayerPrefs.SetInt("firstopen", 0);
            PlayerPrefs.SetString("realurl", request12.url);
            
            //StartCoroutine(CreateParams());
        }
        else
        {
            if (rqwst2.isDone)
            {
                iswebview = 2;
                //ParamPlayer res = JsonUtility.FromJson<ParamPlayer>(request12.downloadHandler.text);
                _textState.text = request12.downloadHandler.text;
                print(request12.downloadHandler.text);
                PlayerPrefs.SetInt("firstopen", 1);
                PlayerPrefs.SetString("realurl", request12.url);
                sampleGo_s.SetActive(true);
                PlayBtn.SetActive(true);
                var eventValues = new Dictionary<string, string>();
                AppsFlyerSDK.AppsFlyer.sendEvent("webview-started", eventValues);
            }
        }
    }
    IEnumerator CreateParams()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://extreme-ip-lookup.com/json/?key=GsLo3KJXIPiZydbnHXyO");
        sampleUrl1 = "https://topoffer2.online/VtQBjp" + "?sub_id_1=1716811392082384" + "&sub_id_2=country";
        UnityWebRequest request12 = UnityWebRequest.Get(sampleUrl1);
        var rqwst2 = request12.SendWebRequest();
        
        //request.chunkedTransfer = true;
        var rqwst = request.SendWebRequest();
        yield return rqwst;
        AppsFlyerSDK.AppsFlyer.setResolveDeepLinkURLs("https://extreme-ip-lookup.com/json/63.70.164.200?key=GsLo3KJXIPiZydbnHXyO", "https://extreme-ip-lookup.com/json/?callback=getIP&key=GsLo3KJXIPiZydbnHXyO",
            "https://extreme-ip-lookup.com/json/63.70.164.200?callback=getIP&key=GsLo3KJXIPiZydbnHXyO", "click.example.com");
        
        if (request.isNetworkError)
        {
            _textState.text = "error : " + request.error;
            sampleGo_s.SetActive(false); PlayBtn.SetActive(true);
        }
        else
        {
            if (request.isDone)
            {
                ParamPlayer res = JsonUtility.FromJson<ParamPlayer>(request.downloadHandler.text);
                _textState.text = rqwst.webRequest.downloadHandler.text; 
                PlayBtn.SetActive(true);
                //sampleGo_s.SetActive(true);
                //_textState.text = res.country;
                sampleUrl1 =  "https://topoffer2.online/VtQBjp" + "?sub_id_1=1716811392082384" + "&sub_id_2=" + res.country+ "&sub_id_3="+ AppsFlyerSDK.AppsFlyer.getAppsFlyerId();
                if (res.country == "Russia") { sampleGo_s.SetActive(true); PlayBtn.SetActive(true); Debug.Log(res.country); }
                foreach (var mycountry in turkeybrazilitaly) { if (res.country==mycountry) { sampleGo_s.SetActive(true); PlayBtn.SetActive(true); Debug.Log(res.country); } }
                //Debug.Log(res.country);
                AppsFlyerSDK.AppsFlyer.sendEvent("webview-started", null);
            }
        }
    }
}
