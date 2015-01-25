using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class QueryEvent {

	public enum EWaitMode
	{
		wmNone,
		wmQuery,
		wmResponse,
		wmHasResults,
	};

	public float countdown;
	public string gameID;
	public EWaitMode waitMode;
	public WWW wwwQuery;

	public List<long>	lResults;

	public static QueryEvent query;

	// Use this for initialization
	public QueryEvent () 
	{
		countdown = 0;
		gameID = "anteater";
		gameID += System.Convert.ToString(/*System.Random () % */1000);
		waitMode = EWaitMode.wmNone;
	}

	public bool IsActive()
	{
		return (countdown > 0) || (waitMode == EWaitMode.wmResponse);
	}
	
	// Update is called once per frame
	public void Update () 
	{
		if (waitMode != EWaitMode.wmNone && waitMode != EWaitMode.wmHasResults)
		{	
			if( !wwwQuery.isDone )
				return;

			Debug.Log ("Query done!");
			if( waitMode == EWaitMode.wmResponse )
			{
				lResults = new List<long>();
				waitMode = EWaitMode.wmHasResults;
				string[] lExtents = wwwQuery.text.Split(';');
				for(uint i = 0; i < lExtents.Length; i ++)
				{
					int iEquals = lExtents[i].LastIndexOf('=');
					if( iEquals < 0 )
						break;
					long nVotes = System.Convert.ToInt32 (lExtents[i].Substring (iEquals + 1));
					Debug.Log (System.Convert.ToString (nVotes));
					lResults.Add(nVotes);
				}
			}
			else
				waitMode = EWaitMode.wmNone;

			return;
		}

		if (!IsActive ())
			return;

		countdown -= Time.deltaTime;

		if (countdown < 0)
		{
			string queryString = "http://www.backworlds.com/whatnow/index.php?id=" + gameID;
			queryString += "&getresponse=1";
			
			wwwQuery = new WWW (queryString);
			waitMode = EWaitMode.wmResponse;
			Debug.Log ("sent query " + queryString);
		}
	}

	public void Activate (float _time, List<LevelParser.SActiveItem> _lItems) 
	{
		countdown = _time;

		string queryString = "http://www.backworlds.com/whatnow/index.php?id=" + gameID;

		queryString += "&query=What%20to%20%20do?";
		uint nItems = 0;
		foreach(LevelParser.SActiveItem item in _lItems)
		{
			queryString += "&response" + System.Convert.ToString (nItems);
			queryString += "=" + item.name;
			nItems++;
		}

		wwwQuery = new WWW (queryString);
		Debug.Log ("sent query " + queryString);
		waitMode = EWaitMode.wmQuery;
	}
}
