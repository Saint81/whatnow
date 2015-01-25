using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum dir{LEFT,RIGHT,UP,DOWN};
public class MapSpawnerScript : MonoBehaviour {
    public float mapOffset = 5.76f;
    public Vector2 currentRoom;
    public GameObject[] roomList;
	public List<Level> levelList;
	// Use this for initialization
	void Start () {
        //initialize first room;
		currentRoom = new Vector2(0,0);
		levelList = new List<Level>();
		currentRoom = new Vector2(0, 0);
		GameObject temp = (GameObject)Instantiate(roomList[0], new Vector3(currentRoom.x * mapOffset, currentRoom.y * mapOffset), Quaternion.identity);
		levelList.Add(new Level(new Vector2(currentRoom.x, currentRoom.y),temp.GetComponent<RoomProperties>().mapFile));

       
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
	public string getCurrentRoomMap()
	{
		foreach(Level lv in levelList)
		{
			if(lv.mCoords == currentRoom)
			{
				return lv.mLevelMap;
			}
		}
		return "ERROR";
	}
	public void moveRoom(dir d)
	{
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
				int rand = Random.Range(0, roomList.GetLength(0));
				GameObject temp = (GameObject)Instantiate(roomList[rand], new Vector3(currentRoom.x * mapOffset, (currentRoom.y + 1) * mapOffset), Quaternion.identity);
				levelList.Add(new Level(new Vector2(currentRoom.x, currentRoom.y + 1),temp.GetComponent<RoomProperties>().mapFile));
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
				int rand = Random.Range(0, roomList.GetLength(0));
				GameObject temp = (GameObject)Instantiate(roomList[rand], new Vector3(currentRoom.x * mapOffset, (currentRoom.y - 1) * mapOffset), Quaternion.identity);
				levelList.Add(new Level(new Vector2(currentRoom.x, currentRoom.y - 1),temp.GetComponent<RoomProperties>().mapFile));
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
				int rand = Random.Range(0, roomList.GetLength(0));
				GameObject temp = (GameObject)Instantiate(roomList[rand], new Vector3((currentRoom.x - 1) * mapOffset, (currentRoom.y) * mapOffset), Quaternion.identity);
				levelList.Add(new Level(new Vector2(currentRoom.x - 1, currentRoom.y ),temp.GetComponent<RoomProperties>().mapFile));
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
				int rand = Random.Range(0, roomList.GetLength(0));
				GameObject temp = (GameObject)Instantiate(roomList[rand], new Vector3((currentRoom.x + 1) * mapOffset, (currentRoom.y) * mapOffset), Quaternion.identity);
				levelList.Add(new Level(new Vector2(currentRoom.x + 1, currentRoom.y ),temp.GetComponent<RoomProperties>().mapFile));
				currentRoom.x++;
			}else{
				currentRoom.x++;
			}
			break;
		}
		}
	}
}
