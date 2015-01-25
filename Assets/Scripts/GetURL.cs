using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetURL : MonoBehaviour {

	void Update () {
		if(QueryEvent.query.IsActive())
			gameObject.GetComponent<Text>().text = QueryEvent.query.GetURL();
	}
}
