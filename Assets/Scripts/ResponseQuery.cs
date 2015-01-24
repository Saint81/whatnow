using UnityEngine;
using System.Collections;

public class ResponseQuery : MonoBehaviour {
	
	public string url = "http://www.backworlds.com/whatnow/index.php?id=whatnow123&getresponse=1";
	
	public IEnumerator QueryResults()
	{
		WWW wwwResponse = new WWW (url);
		yield return wwwResponse;
	}
}
