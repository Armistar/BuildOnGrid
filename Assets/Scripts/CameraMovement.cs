using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public int mapArea = 10;
	private Vector3 mapCenter;

	public float zoomSpeed = 20.0f;
	public float panSpeed = 50.0f;
	public float moveSpeed = 50.0f;
	public int scrollArea = 25;
	public int scrollSpeed = 25;
	public int panAngleMin = 25;
	public int panAngleMax = 60;
	public int zoomMin = 10;
	public int zoomMax = 30;

	private bool isMoving = false;
	

	void Start () 
	{
		Terrain t = GameObject.Find("Terrain").GetComponent<Terrain>();
		mapCenter = new Vector3(t.transform.position.x+t.terrainData.size.x/2,
		                        0,
		                        t.transform.position.z+t.terrainData.size.z/2-14);
	}
	

	void Update () 
	{        
		Vector3 translation = Vector3.zero;

		if(Input.GetMouseButtonDown(1))
		{
			isMoving=true;
		}
		if(Input.GetMouseButtonUp(1))
			isMoving=false;

		float zoomDelta = Input.GetAxis("Mouse ScrollWheel")*zoomSpeed*Time.deltaTime;
		if (zoomDelta!=0)
		{
			translation -= Vector3.up * zoomSpeed * zoomDelta;
		}
		

		float pan = Camera.main.transform.eulerAngles.x - zoomDelta * panSpeed;
		pan = Mathf.Clamp(pan, panAngleMin, panAngleMax);
		if (zoomDelta < 0 || Camera.main.transform.position.y < (zoomMax / 2))
		{
			Camera.main.transform.eulerAngles = new Vector3(pan, 0, 0);
		}

		if(isMoving)
		{
			translation -= new Vector3(Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime, 0, 
			                     	Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime);
		}
		else
		{
			// Move camera if mouse pointer reaches screen borders
			if (Input.mousePosition.x < scrollArea)
			{
				translation += Vector3.right * -scrollSpeed * Time.deltaTime;
			}
			
			if (Input.mousePosition.x >= Screen.width - scrollArea)
			{
				translation += Vector3.right * scrollSpeed * Time.deltaTime;
			}
			
			if (Input.mousePosition.y < scrollArea)
			{
				translation += Vector3.forward * -scrollSpeed * Time.deltaTime;
			}
			
			if (Input.mousePosition.y > Screen.height - scrollArea)
			{
				translation += Vector3.forward * scrollSpeed * Time.deltaTime;
			}
		}

		Vector3 desiredPosition = Camera.main.transform.position + translation;
		if (desiredPosition.x < mapCenter.x-mapArea || mapCenter.x+mapArea < desiredPosition.x)
		{
			translation.x = 0;
		}
		if (desiredPosition.y < zoomMin || zoomMax < desiredPosition.y)
		{
			translation.y = 0;
		}
		if (desiredPosition.z < mapCenter.z-mapArea || mapCenter.z+mapArea < desiredPosition.z)
		{
			translation.z = 0;
		}


		Camera.main.transform.position += translation;
	}
}
