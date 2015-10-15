using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleGenerator : MonoBehaviour 
{
	public List<Obstacle> obstacles;
	private Terrain terrain;
	private float minX;
	private float maxX;
	private float minZ;
	private float maxZ;
	private BoxCollider exeptionZone;

	void Start () 
	{
		terrain = gameObject.GetComponent<Terrain>();
		minX = terrain.transform.position.x;
		minZ = terrain.transform.position.z;
		maxX = minX+terrain.terrainData.size.x+1;
		maxZ = minZ+terrain.terrainData.size.z+1;
		exeptionZone = gameObject.GetComponent<BoxCollider>(); 

		foreach(Obstacle o in obstacles)
		{
			for(int i=0; i<o.amount; i++)
			{
				int q = Random.Range(0, 361);

				GameObject go = Instantiate(o.prefab, Vector3.zero, Quaternion.Euler(new Vector3(0, q, 0))) as GameObject;
				go.transform.parent = gameObject.transform;
				go.transform.position = GetRandomPointOnTerrainBound();
			}
		}

		exeptionZone.enabled = false;
	}

	private Vector3 GetRandomPointOnTerrainBound()
	{
		Vector3 v;
		float x = Random.Range(minX, maxX);
		float z = Random.Range(minZ, maxZ);

		v = new Vector3(x, 0, z);
		if(exeptionZone.bounds.Contains(v))
			v = GetRandomPointOnTerrainBound();
		else return v;
		return v;
	}

}
