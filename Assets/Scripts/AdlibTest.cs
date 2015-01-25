using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	Adlib ad = new Adlib();
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)){
			int rnd = Random.Range(1,6);
			switch(rnd){
			case 1:
				gameObject.GetComponent<Text>().text = ad.Search("weapon");
				break;
			case 2:
				gameObject.GetComponent<Text>().text = ad.Search("health");
				break;
			case 3:
				gameObject.GetComponent<Text>().text = ad.Search("tool");
				break;
			case 4:
				gameObject.GetComponent<Text>().text = ad.Search("food");
				break;
			case 5:
				gameObject.GetComponent<Text>().text = ad.Search("trap");
				break;
			}
		}
	}
}
