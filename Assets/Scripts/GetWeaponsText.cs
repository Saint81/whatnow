using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetWeaponsText : MonoBehaviour {

	public HealthSystem player;
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text = player.sweapons.ToString() + "/" + player.mweapons.ToString();
	}
}
