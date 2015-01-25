using UnityEngine;
using System.Collections;

public class GetWeapons : MonoBehaviour {

	public HealthSystem player;

	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3((float)player.sweapons / player.mweapons, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
	}
}
