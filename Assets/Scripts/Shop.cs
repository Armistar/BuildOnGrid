using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
	public GameObject shopItemTemplate;
	public List<ShopItem> shopItemsList;
	
	void Awake () 
	{
		for(int i=0; i<shopItemsList.Count; i++)
		{
			GameObject go = Instantiate(shopItemTemplate, Vector3.zero, Quaternion.identity) as GameObject;
			go.transform.parent = gameObject.transform;
			go.transform.localScale = new Vector3(1,1,1);
			Item item = go.GetComponent<Item>();
			item.model = shopItemsList[i].model;
			item.icon.spriteName = shopItemsList[i].icon.name;
			item.label.text = shopItemsList[i].name; 
		}
		GameObject.Find("ShopWindow").SetActive(false);
	}

	public void CancelPreviousItem()
	{
		Destroy(GameObject.FindWithTag("ItemToBuild"));
	}

}
