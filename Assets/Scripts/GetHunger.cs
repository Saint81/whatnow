using UnityEngine;
using System.Collections;

public class GetHunger : MonoBehaviour {

	public HealthSystem player;
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3((float)player.Hunger / 100, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
	}
}
