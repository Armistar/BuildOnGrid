using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public UISprite progressBar;
	private float currenTime;
	private float timeNeeded = 60.0f;

	void Update () 
	{
		currenTime+=Time.deltaTime;
		progressBar.fillAmount = currenTime/timeNeeded;

		if(currenTime>=timeNeeded)
			currenTime=0;

		if(Input.GetKey(KeyCode.Escape))
			Application.Quit();
	}
}
