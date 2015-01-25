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

	public long iVoteResult;

	public static QueryEvent query;

	public string GetURL()
	{
		return "http://www.backworlds.com/whatnow/?id=" + gameID;
	}

	// Use this for initialization
	public QueryEvent () 
	{
		countdown = 0;
		gameID = "anteater";

		System.Random rand = new System.Random();
		gameID += System.Convert.ToString(rand.Next() % 1000);
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
				iVoteResult = 0;
				List<long> lResults = new List<long>();
				waitMode = EWaitMode.wmHasResults;
				string[] lExtents = wwwQuery.text.Split(';');
				
				System.Random rand = new System.Random();
				for(int i = 0; i < lExtents.Length; i ++)
				{
					int iEquals = lExtents[i].LastIndexOf('=');
					if( iEquals < 0 )
						break;
					long nVotes = System.Convert.ToInt32 (lExtents[i].Substring (iEquals + 1));
					Debug.Log (System.Convert.ToString (nVotes));
					lResults.Add(nVotes);
					if( nVotes > lResults[(int)iVoteResult] ||
					    nVotes == lResults[(int)iVoteResult] && ((rand.Next() & 1) != 0))
						iVoteResult = i;
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
			CloseQuery();
	}

	public void CloseQuery()
	{
		countdown = 0;

		string queryString = GetURL();
		queryString += "&getresponse=1";
		
		wwwQuery = new WWW (queryString);
		waitMode = EWaitMode.wmResponse;
		Debug.Log ("sent query " + queryString);
	}

	public void Activate (float _time, List<LevelParser.SActiveItem> _lItems) 
	{
		countdown = _time;

		string queryString = GetURL();

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

	public int GrabResults()
	{
		waitMode = EWaitMode.wmNone;
		return (int)iVoteResult;
	}
}
