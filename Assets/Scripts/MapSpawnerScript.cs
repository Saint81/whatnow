using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum dir{LEFT,RIGHT,UP,DOWN};
public class MapSpawnerScript : MonoBehaviour {
    public float mapOffset = 5.76f;
    public Vector2 currentRoom;
    public GameObject[] roomList;
	public List<Level> levelList;
	public Level nextLevel;
	public GameObject nextLevelObject;
	public bool isNewLevel;

	// Use this for initialization
	void Start () {
        //initialize first room;
		initialize();
	}
	public void initialize()
	{
		if(levelList == null)
		{
			levelList = new List<Level>();
			currentRoom = new Vector2(0, 0);
			GameObject temp = (GameObject)Instantiate(roomList[0], new Vector3(currentRoom.x * mapOffset, currentRoom.y * mapOffset), Quaternion.identity);
			levelList.Add(new Level(new Vector2(currentRoom.x, currentRoom.y),temp.GetComponent<RoomProperties>().mapFile));
			isNewLevel = true;
			GenerateNextRoom();
		}
	}
	// Update is called once per frame
	void Update () {
	    
	}

	public string getCurrentRoomMap()
	{
		if(levelList != null)
		{
		foreach(Level lv in levelList)
		{
			if(lv.mCoords == currentRoom)
			{
				return lv.mLevelMap;
			}
		}
		}else{
			Debug.Log ("ERROR");
			return "ERROR";
		}
		return "ERROR";
	}

	void GenerateNextRoom()
	{
		QueryEvent.Get().CloseQuery();
		int rand = Random.Range(2, roomList.GetLength(0));
		nextLevelObject = (GameObject)Instantiate(roomList[rand], new Vector3(0 * mapOffset, 0 * mapOffset), Quaternion.identity);
		nextLevel = new Level(new Vector2(0,0), nextLevelObject.GetComponent<RoomProperties>().mapFile);
	
		// Need to parse level to send query
		LevelItemParser parser = new LevelItemParser();
		parser.ParseLevel(nextLevel.mLevelMap);	
		QueryEvent.Get().Activate(5.0f, parser.lActiveItems);
	}

	public void moveRoom(dir d)
	{
		int nLevelsOld = levelList.Count;
		switch(d)
		{
		case dir.UP:
		{
			bool exist = false ;
			Debug.Log (levelList.Count);
			foreach(Level lv in levelList)
			{
				//check if that spot is already taken
				if(lv.mCoords == new Vector2(currentRoom.x,currentRoom.y+1))
				{
					exist = true;
				}
			}
			if(!exist)
			{
				//make new room
				/*
				int rand = Random.Range(0, roomList.GetLength(0));
				GameObject temp = (GameObject)Instantiate(roomList[rand], new Vector3(currentRoom.x * mapOffset, (currentRoom.y + 1) * mapOffset), Quaternion.identity);
				levelList.Add(new Level(new Vector2(currentRoom.x, currentRoom.y + 1),temp.GetComponent<RoomProperties>().mapFile));
				*/
				nextLevel.mCoords.x = currentRoom.x;
				nextLevel.mCoords.y = currentRoom.y + 1;
				nextLevelObject.gameObject.transform.position = new Vector3(currentRoom.x * mapOffset, (currentRoom.y + 1) * mapOffset);
				levelList.Add (nextLevel);
				GenerateNextRoom();
				currentRoom.y++;
			}else{
				currentRoom.y++;
			}
			break;
		}
		case dir.DOWN:
		{
			bool exist = false ;
			foreach(Level lv in levelList)
			{
				//check if that spot is already taken
				if(lv.mCoords == new Vector2(currentRoom.x,currentRoom.y-1))
				{
					exist = true;
				}
			}
			if(!exist)
			{
				//make new room
				nextLevel.mCoords.x = currentRoom.x;
				nextLevel.mCoords.y = currentRoom.y - 1;
				nextLevelObject.gameObject.transform.position = new Vector3(currentRoom.x * mapOffset, (currentRoom.y - 1) * mapOffset);
				levelList.Add (nextLevel);
				GenerateNextRoom();
				currentRoom.y--;
			}else{
				currentRoom.y--;
			}
			break;
		}
		case dir.LEFT:
		{
			bool exist = false ;
			foreach(Level lv in levelList)
			{
				//check if that spot is already taken
				if(lv.mCoords == new Vector2(currentRoom.x - 1,currentRoom.y))
				{
					exist = true;
				}
			}
			if(!exist)
			{
				//make new room
				nextLevel.mCoords.x = currentRoom.x-1;
				nextLevel.mCoords.y = currentRoom.y;
				nextLevelObject.gameObject.transform.position = new Vector3((currentRoom.x - 1) * mapOffset, currentRoom.y * mapOffset);
				levelList.Add (nextLevel);
				GenerateNextRoom();
				currentRoom.x--;
			}else{
				currentRoom.x--;
			}
			break;
		}
		case dir.RIGHT:
		{
			bool exist = false ;
			foreach(Level lv in levelList)
			{
				//check if that spot is already taken
				if(lv.mCoords == new Vector2(currentRoom.x + 1,currentRoom.y))
				{
					exist = true;
				}
			}
			if(!exist)
			{
				//make new room
				nextLevel.mCoords.x = currentRoom.x+1;
				nextLevel.mCoords.y = currentRoom.y;
				nextLevelObject.gameObject.transform.position = new Vector3((currentRoom.x + 1) * mapOffset, currentRoom.y * mapOffset);
				levelList.Add (nextLevel);
				GenerateNextRoom();
				currentRoom.x++;
			}else{
				currentRoom.x++;
			}
			break;
		}
		}
		isNewLevel = ( nLevelsOld != levelList.Count );
	}
}
