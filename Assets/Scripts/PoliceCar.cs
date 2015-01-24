using UnityEngine;
using System.Collections;

public class PoliceCar : Container {
	
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
				//player gets weapon
			case 2:
				break;
				//player gets tool
			case 3:
				break;
				//player gets hurt
			default:
				break;
				//nothing happens
			}
		}
	}
}
