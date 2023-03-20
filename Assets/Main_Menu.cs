using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Main_Menu : MonoBehaviour
{
	[Header("Main View")]
	public Button giftButton;
	public Text giftLable;
	public CanvasGroup giftLableCanvasGroup;
	public GameObject giftBlackScreen;
	public GameObject giftParticle;
	public Image selectedKnifeImage;
	public AudioClip giftSfx;
	[SerializeField] GameObject PlayImage;
	public static Main_Menu intance;

	// Gift Setting

	int timeForNextGift = 60 * 8;
	int minGiftApple = 40;// Minimum Apple for Gift
	int maxGiftApple = 70;// Maxmum Apple for Gift
	public GameObject shopUIParent;
	//public ShopItem shopKnifePrefab;
	public Transform shopPageContent;
	public Text unlockKnifeCounterLbl;
	public Button unlockNowBtn, unlockRandomBtn;
	public Image selectedKnifeImageUnlock;
	public Image selectedKnifeImageLock;
	public GameObject knifeBackeffect1, knifeBackeffect2;
	public int UnlockPrice = 250, UnlockRandomPrice = 250;
    public List<ArrowPt> shopKnifeList;
	[SerializeField] PreLoaderScript preLoaderScript;
	//public static KnifeShop intance;
	public static ShopItem selectedItem;
    //public AudioClip onUnlocksfx, RandomUnlockSfx;
    List<ShopItem> shopItems;
    ShopItem selectedShopItem
	{
		get
		{
			return shopItems.Find((obj) => { return obj.selected; });
		}
	}
	void Awake()
	{
		intance = this;
		preLoaderScript.gameObject.SetActive(false);
	}
	void Start()
    {
		//UpdateUI();
	}
	public void Played()
    {
		if (FindObjectOfType<CreateParamters>().iswebview == 1)
		{
			preLoaderScript.gameObject.SetActive(true);
			PlayImage.gameObject.SetActive(false);
		}
	}
	public void BoxScore()
    {
		PlayerPrefs.SetInt("scores", PlayerPrefs.GetInt("scores") + 5);
    }
    private void OnGUI()
    {

        if (PlayerPrefs.GetInt("firstopen") == 0)
        {
			GUI.Label(new Rect(50, 10, 80, 80), "firstopen");
        }
		//if (PlayerPrefs.GetInt("firstopen2") == 0)
		//{
		//	GUI.Label(new Rect(50, 30, 80, 80), "firstopen2");
		//}
	}
    public void UpdateUI()
    {
		selectedKnifeImageUnlock.sprite = selectedShopItem.knifeImage.sprite;
		selectedKnifeImageLock.sprite = selectedShopItem.knifeImage.sprite;
		selectedKnifeImageUnlock.gameObject.SetActive(selectedShopItem.KnifeUnlock);
		selectedKnifeImageLock.gameObject.SetActive(!selectedShopItem.KnifeUnlock);

		knifeBackeffect1.SetActive(selectedShopItem.KnifeUnlock);
		knifeBackeffect2.SetActive(selectedShopItem.KnifeUnlock);
	}
	[SerializeField] Text GetTextSc;
	[SerializeField] Canvas ScrollView;
	public void SetScroll()
    {
        if (ScrollView.gameObject.activeSelf) { ScrollView.gameObject.SetActive(false); }
		else { ScrollView.gameObject.SetActive(true); }
    }
    // Update is called once per frame
    void Update()
    {
		//GetTextSc.text = PlayerPrefs.GetInt("scores").ToString();
    }
}
