using UnityEngine;
using System.Collections;

public class Car : Container {

	public void Search(){
		if(trapped){
			//player takes damage
		}
		else{
			Random rnd = new Random();
			int happen = (int)Mathf.Round(Random.value * 4);
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
