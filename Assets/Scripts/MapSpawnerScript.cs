using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MapSpawnerScript : MonoBehaviour {
    public float mapOffset = 5.76f;
    public Vector2 currentRoom;
    public GameObject[] roomList;
	public List<Level> levelList;
	// Use this for initialization
	void Start () {
        //initialize first room;
		levelList = new List<Level>();
        levelList.Add(new Level(new Vector2(0,0)));
        Instantiate(roomList[0], new Vector3(0, 0, 0), Quaternion.identity);
        currentRoom = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.W))
        {
            bool exist = false ;
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
               Instantiate(roomList[rand], new Vector3(currentRoom.x * mapOffset, (currentRoom.y + 1) * mapOffset), Quaternion.identity);
               levelList.Add(new Level(new Vector2(currentRoom.x, currentRoom.y + 1)));
				currentRoom.y++;
            }else{
				currentRoom.y++;
			}
        }
		if(Input.GetKeyDown(KeyCode.S))
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
				Instantiate(roomList[rand], new Vector3(currentRoom.x * mapOffset, (currentRoom.y - 1) * mapOffset), Quaternion.identity);
				levelList.Add(new Level(new Vector2(currentRoom.x, currentRoom.y - 1)));
				currentRoom.y--;
			}else{
				currentRoom.y--;
			}
		}
		if(Input.GetKeyDown(KeyCode.A))
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
				Instantiate(roomList[rand], new Vector3((currentRoom.x - 1) * mapOffset,currentRoom.y * mapOffset), Quaternion.identity);
				levelList.Add(new Level(new Vector2(currentRoom.x - 1, currentRoom.y)));
				currentRoom.x--;
			}else{
				currentRoom.x--;
			}
		}
		if(Input.GetKeyDown(KeyCode.D))
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
				Instantiate(roomList[rand], new Vector3((currentRoom.x + 1) * mapOffset,currentRoom.y * mapOffset), Quaternion.identity);
				levelList.Add(new Level(new Vector2(currentRoom.x + 1, currentRoom.y)));
				currentRoom.x++;
			}else{
				currentRoom.x++;
			}
		}
	}
}
