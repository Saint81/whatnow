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
	public string queuedQuery;
	public EWaitMode waitMode;
	public WWW wwwQuery;

	public string voteResult;

	public static QueryEvent query;

	public string GetURL()
	{
		return "http://www.backworlds.com/whatnow/?id=" + gameID;
	}

	public static QueryEvent Get()
	{
		if( query == null )
			query = new QueryEvent();
		return query;
	}

	// Use this for initialization
	public QueryEvent () 
	{
		countdown = 0;
		gameID = "anteater";
		queuedQuery = null;

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
				long iVoteResult = 0;
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
					{
						iVoteResult = i;
						voteResult = lExtents[i].Substring(0, iEquals);
					}
				}
			}
			else
				waitMode = EWaitMode.wmNone;

			if( queuedQuery != null )
			{
				wwwQuery = new WWW (queuedQuery);
				Debug.Log ("sent query " + queuedQuery);
				waitMode = EWaitMode.wmQuery;
				queuedQuery = null;
			}

			return;
		}

		if (!IsActive ())
			return;

		countdown -= Time.deltaTime;
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

	public void Activate (float _time, List<LevelParser.SActiveItem> _lItems, string _fileName) 
	{
		countdown = _time;

		string queryString = GetURL();

		string newFile = _fileName.Substring (0, _fileName.Length - 4) + ".png";
        queryString += "&query=" + newFile;
		uint nItems = 0;
		foreach(LevelParser.SActiveItem item in _lItems)
		{
			if( !item.isFirst || item.noSabotage )
				continue;

			queryString += "&response" + System.Convert.ToString (nItems);
			queryString += "=" + item.name;
			nItems++;
		}
		
		/*
		wwwQuery = new WWW (queryString);
		Debug.Log ("sent query " + queryString);
		waitMode = EWaitMode.wmQuery;
		*/
		queuedQuery = queryString;
	}

	public void Cleanup ()
	{
		string queryString = GetURL();
		queryString += "&cleanup=1";
		wwwQuery = new WWW(queryString);
		Debug.Log ("sent query " + queryString);
	}
}
