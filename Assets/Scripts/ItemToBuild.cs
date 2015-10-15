using UnityEngine;
using System.Collections;

public class ItemToBuild : MonoBehaviour 
{
	
	void Start () 
	{
		gameObject.tag = "ItemToBuild";
	}
	

	void FixedUpdate () 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(ray, out hit))
		gameObject.transform.position = hit.point;
	}
}
