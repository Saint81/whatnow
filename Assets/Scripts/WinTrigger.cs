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
		if((playerPos.position.y >= winRangeYMin || playerPos.position.y <= winRangeYMax) &&
		   (playerPos.position.x >= winRangeXMin || playerPos.position.x <= winRangeXMax))
		{
			StartCoroutine(winCondition.Death());
		}
	}
}
