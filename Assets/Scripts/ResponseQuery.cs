using UnityEngine;
using System.Collections;

public class ResponseQuery : MonoBehaviour {
	
	public string url = "http://tommyhtran.com/VotePage/index.php?id=whatnow123&getresponse=1";
	
	public IEnumerator QueryResults()
	{
		WWW wwwResponse = new WWW (url);
		yield return wwwResponse;
	}
}
