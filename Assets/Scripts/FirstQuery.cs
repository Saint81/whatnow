using UnityEngine;
using System.Collections;

public class FirstQuery : MonoBehaviour {

	public string url = "http://www.backworlds.com/whatnow/index.php?id=whatnow123";
	public ResponseQuery something;

	IEnumerator DecisionTime()
	{
		WWW wwwQuery = new WWW (url);
		yield return wwwQuery;
	}
}
