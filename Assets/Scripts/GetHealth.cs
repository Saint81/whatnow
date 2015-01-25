using UnityEngine;
using System.Collections;

public class GetHealth : MonoBehaviour {

	public HealthSystem player;
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3((float)player.HP / 100, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
	}
}
