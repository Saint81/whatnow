using UnityEngine;
using System.Collections;

public class PostGame : MonoBehaviour {
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(1);
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
