using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	bool trapped;

	public void Search(){
		if(trapped){
			//player takes damage
		}
		else{
			Random rnd = new Random();
			int happen = (int)Mathf.Round(Random.value * 5);
			switch(happen)
			{
			case 1:
				break;
				//player gets food
			case 2:
				break;
				//player gets tool
			default:
				break;
				//nothing happens
			}
		}
	}
}
