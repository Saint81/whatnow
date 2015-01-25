using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerHandler {


	public static Adlib ad = new Adlib();
	// Called when the player interacts with an item
	public static void HandleAction(string _Item, bool _bIsTrap, int _X, int _Y)
	{
		if(_bIsTrap){
			Camera.main.transform.GetComponent<CameraShakeScript>().shake = 1f;
			GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("trap");
			GameObject.Find("Player").GetComponent<HealthSystem>().HP -= 15;
		}
		else{
			int rnd;
			if(_Item == "Car"){
				rnd = Random.Range(1,9);
				switch(rnd){
				case 1:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("weapon");
					GameObject.Find("Player").GetComponent<HealthSystem>().sweapons++;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().sweapons > GameObject.Find("Player").GetComponent<HealthSystem>().mweapons)
						GameObject.Find("Player").GetComponent<HealthSystem>().sweapons = GameObject.Find("Player").GetComponent<HealthSystem>().mweapons;
					break;
				case 2:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("food");
					GameObject.Find("Player").GetComponent<HealthSystem>().Hunger += 25;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().Hunger > 100)
						GameObject.Find("Player").GetComponent<HealthSystem>().Hunger = 100;
					break;
				case 3:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("health");
					GameObject.Find("Player").GetComponent<HealthSystem>().HP += 10;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().HP > 100)
						GameObject.Find("Player").GetComponent<HealthSystem>().HP = 100;
					break;
				default:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("none");
					break;
				}
			}
			if(_Item == "Robot"){
				rnd = Random.Range(1,6);
				switch(rnd){
				case 1:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("weapon");
					GameObject.Find("Player").GetComponent<HealthSystem>().sweapons++;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().sweapons > GameObject.Find("Player").GetComponent<HealthSystem>().mweapons)
						GameObject.Find("Player").GetComponent<HealthSystem>().sweapons = GameObject.Find("Player").GetComponent<HealthSystem>().mweapons;
					break;
				case 2:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("tool");
					GameObject.Find("Player").GetComponent<HealthSystem>().stools++;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().stools > GameObject.Find("Player").GetComponent<HealthSystem>().mtools)
						GameObject.Find("Player").GetComponent<HealthSystem>().stools = GameObject.Find("Player").GetComponent<HealthSystem>().mtools;
					break;
				default:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("none");
					break;
				}
			}
			if(_Item == "Trashcan"){
				rnd = Random.Range(1,8);
				switch(rnd){
				case 1:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("food");
					GameObject.Find("Player").GetComponent<HealthSystem>().Hunger += 25;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().Hunger > 100)
						GameObject.Find("Player").GetComponent<HealthSystem>().Hunger = 100;
					break;
				default:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("none");
					break;
				}
			}
			if(_Item == "Corpse"){
				rnd = Random.Range(1,10);
				switch(rnd){
				case 1:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("weapon");
					GameObject.Find("Player").GetComponent<HealthSystem>().sweapons++;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().sweapons > GameObject.Find("Player").GetComponent<HealthSystem>().mweapons)
						GameObject.Find("Player").GetComponent<HealthSystem>().sweapons = GameObject.Find("Player").GetComponent<HealthSystem>().mweapons;
					break;
				case 2:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("tool");
					GameObject.Find("Player").GetComponent<HealthSystem>().stools++;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().stools > GameObject.Find("Player").GetComponent<HealthSystem>().mtools)
						GameObject.Find("Player").GetComponent<HealthSystem>().stools = GameObject.Find("Player").GetComponent<HealthSystem>().mtools;
					break;
				case 3:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("health");
					GameObject.Find("Player").GetComponent<HealthSystem>().HP += 10;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().HP > 100)
						GameObject.Find("Player").GetComponent<HealthSystem>().HP = 100;
					break;
				default:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("none");
					break;
				}
			}
			if(_Item == "Kiosk"){
				rnd = Random.Range(1,6);
				switch(rnd){
				case 1:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("tool");
					GameObject.Find("Player").GetComponent<HealthSystem>().stools++;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().stools > GameObject.Find("Player").GetComponent<HealthSystem>().mtools)
						GameObject.Find("Player").GetComponent<HealthSystem>().stools = GameObject.Find("Player").GetComponent<HealthSystem>().mtools;
					break;
				case 2:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("food");
					GameObject.Find("Player").GetComponent<HealthSystem>().Hunger += 25;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().Hunger > 100)
						GameObject.Find("Player").GetComponent<HealthSystem>().Hunger = 100;
					break;
				default:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("none");
					break;
				}
			}
			if(_Item == "Building"){
				rnd = Random.Range(1,6);
				switch(rnd){
				case 1:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("weapon");
					GameObject.Find("Player").GetComponent<HealthSystem>().sweapons++;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().sweapons > GameObject.Find("Player").GetComponent<HealthSystem>().mweapons)
						GameObject.Find("Player").GetComponent<HealthSystem>().sweapons = GameObject.Find("Player").GetComponent<HealthSystem>().mweapons;
					break;
				case 2:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("food");
					GameObject.Find("Player").GetComponent<HealthSystem>().Hunger += 25;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().Hunger > 100)
						GameObject.Find("Player").GetComponent<HealthSystem>().Hunger = 100;
					break;
				case 3:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("health");
					GameObject.Find("Player").GetComponent<HealthSystem>().HP += 10;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().HP > 100)
						GameObject.Find("Player").GetComponent<HealthSystem>().HP = 100;
					break;
				case 4:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("tool");
					GameObject.Find("Player").GetComponent<HealthSystem>().stools++;
					if(GameObject.Find("Player").GetComponent<HealthSystem>().stools > GameObject.Find("Player").GetComponent<HealthSystem>().mtools)
						GameObject.Find("Player").GetComponent<HealthSystem>().stools = GameObject.Find("Player").GetComponent<HealthSystem>().mtools;
					break;
				default:
					GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = ad.Search("none");
					break;
				}
			}
		}
	}

	// Called when the player interacts with an item after triggering a trap
	public static void HandleActionPostTrapTrigger()
	{
		GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = "This area is no longer safe to search. Get out of there!";
	}

	// Called when the player interacts with an item in a previously visited room
	public static void HandleActionInEmptyRoom()
	{
		GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = "You have already been through this area; there is nothing to search";
	}
}
