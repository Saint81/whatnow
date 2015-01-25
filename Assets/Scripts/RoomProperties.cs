using UnityEngine;
using System.Collections;

public class RoomProperties : MonoBehaviour {
	public string mapFile;
	// Use this for initialization
	void Start () {
	if(mapFile == null)
		{
			mapFile = "test.txt";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
