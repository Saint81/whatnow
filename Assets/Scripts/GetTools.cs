using UnityEngine;
using System.Collections;

public class GetTools : MonoBehaviour {

	public HealthSystem player;
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3((float)player.stools / player.mtools, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
	}
}
