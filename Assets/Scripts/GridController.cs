using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridController : MonoBehaviour 
{
	public int sizeX = 10;
	public int sizeY = 10;
	public GameObject cell;
	private List<Cell> grid;

	void Start () 
	{
		grid = new List<Cell>();
		BuildGrid();
	}

	private void BuildGrid()
	{
		for(int i=0; i<sizeX;i++)
		{
			for(int j=0; j<sizeY; j++)
			{
				GameObject go = Instantiate(cell, new Vector3(i*3, 0, j*3), Quaternion.identity) as GameObject;
				grid.Add(go.GetComponent<Cell>());
				go.transform.parent = gameObject.transform;
			}
		}
	}

	public void ToggleGrid()
	{
		foreach(Cell cell in grid)
			cell.ToggleCellBorder();
	}
	
}
