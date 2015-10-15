using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour 
{
	private MeshRenderer border;
	private bool isEmpty = true;

	void Start()
	{
		border = gameObject.GetComponentInChildren<MeshRenderer>();
	}

	void OnMouseDown()
	{
		if(isEmpty)
		{
		GameObject go = GameObject.FindWithTag("ItemToBuild");
		if(go != null)
		{
			go.transform.parent = gameObject.transform;
			go.transform.position = gameObject.transform.position;
			go.tag = tag;
			Destroy(go.GetComponent<ItemToBuild>());
			isEmpty = false;
		}
		}
	}

	public void ToggleCellBorder()
	{
		border.enabled = !border.enabled;
	}
}
