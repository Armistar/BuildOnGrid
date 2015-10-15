using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour 
{
	public GameObject model;
	public UISprite icon;
	public UILabel label;

	public void ItemClicked()
	{
		GameObject go = Instantiate(model, Vector3.zero, Quaternion.identity) as GameObject;
		go.AddComponent<ItemToBuild>();
		GameObject.Find("ShopWindow").SetActive(false);
	}
}
