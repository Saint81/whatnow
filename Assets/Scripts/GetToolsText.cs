using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetToolsText : MonoBehaviour {
	public HealthSystem player;
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text = player.stools.ToString() + "/" + player.mtools.ToString();
	}
}
