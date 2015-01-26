using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

	DeathByWinning winCondition;
	PlayerController playerPos;
	public float winRangeYMin, winRangeYMax;
	public float winRangeXMin, winRangeXMax;

	void Start()
	{
		playerPos = GetComponent<PlayerController>();
		winCondition = GetComponent<DeathByWinning>();
	}

	void Update() 
	{
		//if player enters range, start coroutine
		if(GameObject.Find("MapSpawner1").GetComponent<MapSpawnerScript>().winRoom == playerPos.mCurrentRoom)
		{
			//.Log(playerPos.position);

			StartCoroutine(winCondition.Death());
		}
	}
}
