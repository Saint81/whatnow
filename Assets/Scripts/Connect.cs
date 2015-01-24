using UnityEngine;
using System.Collections;

public class Connect : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		WWW www = new WWW("http://www.backworlds.com/whatnow/index.php?id=whatnow123&query=A or B&response0=Option A&response1=Option B");
		yield return www;
		Debug.Log(www.text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
