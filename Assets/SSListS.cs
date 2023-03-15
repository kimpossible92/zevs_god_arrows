using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item{
	public string itemName;
	public Sprite icon;
	public float price = 1;
}

public class SSListS : MonoBehaviour {

	public List<Item> itemList;
	public GameObject[] shopButtons;
	public List<GameObject> shopButtonsList;
	public Transform contentPanel;
	public SSListS otherShop;
	public Text myGoldDisplayText;
	public GameObject buttonPrefab;
	public float gold = 3f;

	void Start () {
		RefreshDisplay ();

//		newButton.transform.SetParent (contentPanel);
	}

	public void RefreshDisplay(){
		myGoldDisplayText.text = "Gold: " + gold.ToString ();
		RemoveButtons ();
		AddButtons ();
	}
	
	private void AddButtons(){
		for (int i = 0; i < itemList.Count; i++) {
//			GameObject newButton = (GameObject) Instantiate (buttonPrefab, contentPanel, false);
			GameObject newButton = Instantiate (buttonPrefab, contentPanel);
			shopButtonsList.Add (newButton);
//			shopButtons [i].SetActive (true);
			Item item = itemList [i];

//			shopButtons [i].GetComponent<SampleButton>().Setup (item, this);
			newButton.GetComponent<SampleButton>().Setup (item, this);
		}
	}

	private void RemoveButtons(){
//		foreach (var shopButton in shopButtons) {
//			shopButton.SetActive (false);
//		}
		foreach (var shopButton in shopButtonsList) {
			Destroy (shopButton);
		}
	}

	public void TryTransferItemToOtherShop(Item item){
		if (otherShop.gold >= item.price) {
			gold += item.price;
			otherShop.gold -= item.price;
            AddItem(item, otherShop);
			RemoveItem (item, this);

			RefreshDisplay ();
			otherShop.RefreshDisplay ();
		}
	}

	private void AddItem(Item itemToAdd, SSListS shopList){
		shopList.itemList.Add (itemToAdd);
		if(FindObjectOfType<FBInitial>().listS == this) FindObjectOfType<FBInitial>().setSSlist();
	}

	private void RemoveItem(Item itemToRemove, SSListS shopList){
		shopList.itemList.Remove (itemToRemove);
	}
}
