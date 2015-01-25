using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetHungerText : MonoBehaviour {

	public HealthSystem player;
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text = player.Hunger.ToString();
	}
}
