using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	//position is the real position, while move is a representive on-screen position
	public Camera mainCamera;
	public Vector2 position;
	public Vector2 direction;
	public Vector2 mCurrentRoom;
	public Mover targetPlayer;
	public HealthSystem playerHP;
	public GameObject target;
	public MapSpawnerScript spawn;
	public bool actionHeld;
	public LevelParser levelparser;
	public List<LevelParser.SActiveItem> lActiveItems;
	public TileType[,] map;
	public static bool isWaitingForAudience;
	
	void Start()
	{
		spawn.initialize();
		map = levelparser.ParseLevel(spawn.getCurrentRoomMap());
		target.GetComponent<SpriteRenderer>().sprite = targetPlayer.walkAnim[0];
		lActiveItems = levelparser.lActiveItems;
		QueryEvent.query = new QueryEvent();
		QueryEvent.query.Activate(5.0f, levelparser.lActiveItems);
		direction = new Vector2(0.0f, 1.0f);
		mCurrentRoom = spawn.currentRoom;
		actionHeld = true;
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		
		if( QueryEvent.query.IsActive() )
		{
			QueryEvent.query.Update();
			return;
		}

		if(Input.GetKey(KeyCode.W) && !targetPlayer.isMoving)
		{
			direction = new Vector2(0.0f, -1.0f);
			if(position.y - 1 >= 0 && map[(int)position.y - 1,(int)position.x] == TileType.EMPTY)
			{
				StartCoroutine( targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, -direction));
				position.y -= 1;
			}else if((position.x <= 10 && position.x >= 7) && position.y == 0)
			{
				//create a new room
				spawn.moveRoom(dir.UP);
				string newMap = spawn.getCurrentRoomMap();
				map = levelparser.ParseLevel(newMap);
				StartCoroutine(targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, -direction));
				position.y = 17;
			}
			target.GetComponent<SpriteRenderer>().sprite = targetPlayer.walkUpAnim[0];
		}

		if(Input.GetKey(KeyCode.S) && !targetPlayer.isMoving)
		{
			direction = new Vector2(0.0f, 1.0f);
			if(position.y + 1 < map.GetLength(0) && map[(int)position.y + 1,(int)position.x] == TileType.EMPTY)
			{
				StartCoroutine( targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, -direction));
				position.y += 1;
			}
			else if((position.x <= 10 && position.x >= 7) && position.y == 17)
			{
				//create a new room
				spawn.moveRoom(dir.DOWN);
				string newMap = spawn.getCurrentRoomMap();
				map = levelparser.ParseLevel(newMap);
				StartCoroutine(targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, -direction));
				position.y = 0;
				
			}
			target.GetComponent<SpriteRenderer>().sprite = targetPlayer.walkAnim[0];
		}

		if(Input.GetKey(KeyCode.D) && !targetPlayer.isMoving)
		{
			direction = new Vector2(1.0f, 0.0f);
			if(position.x + 1 < map.GetLength(1) && map[(int)position.y,(int)position.x + 1] == TileType.EMPTY)
			{
				StartCoroutine( targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
				position.x += 1;
			}
			else if((position.y <= 10 && position.y >= 7) && position.x == 17)
			{
				//create a new room
				spawn.moveRoom(dir.RIGHT);
				string newMap = spawn.getCurrentRoomMap();
				map = levelparser.ParseLevel(newMap);
				StartCoroutine(targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
				position.x = 0;
				
			}				
			target.GetComponent<SpriteRenderer>().sprite = targetPlayer.walkSideAnim[0];
			transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
		}

		if(Input.GetKey(KeyCode.A) && !targetPlayer.isMoving)
		{
			direction = new Vector2(-1.0f, 0.0f);
			if(position.x - 1 >= 0 && map[(int)position.y,(int)position.x - 1] == TileType.EMPTY)
			{
				StartCoroutine( targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
				position.x -= 1;
			}
			else if((position.y <= 10 && position.y >= 7) && position.x == 0)
			{
				//create a new room
				spawn.moveRoom(dir.LEFT);
				string newMap = spawn.getCurrentRoomMap();
				map = levelparser.ParseLevel(newMap);
				StartCoroutine(targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
				position.x = 17;
				
			}				
			target.GetComponent<SpriteRenderer>().sprite = targetPlayer.walkSideAnim[0];
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}

		if(mCurrentRoom != spawn.currentRoom)
		{
			Camera.main.transform.position = new Vector3(spawn.currentRoom.x * spawn.mapOffset , spawn.currentRoom.y * spawn.mapOffset, -10.0f);
			mCurrentRoom = spawn.currentRoom;
		}

		if(Input.GetKey (KeyCode.Space))
		{
			int x = (int)(position.x + direction.x);
			int y = (int)(position.y + direction.y);
		
			// If it's an activatable tile, find the closest one
			if( !actionHeld && !targetPlayer.isMoving &&
			   	x >= 0 && y >= 0 && 
			    x < map.GetLength(0) && y < map.GetLength(1) && 
			    map[y,x] == TileType.ITEM && 
			    lActiveItems.Count > 0 )
			{
				int ClosestDist = 100000;
				int iActiveItem = 0;
				for(int i = 0; i < lActiveItems.Count; i++)
				{
					LevelParser.SActiveItem item = lActiveItems[i];
					int Dist = System.Math.Abs(item.x - x) + System.Math.Abs(item.y - y);
					if( Dist < ClosestDist )
					{
						iActiveItem = i;
						ClosestDist = Dist;
					}
				}

				LevelParser.SActiveItem pickedItem = lActiveItems[iActiveItem];
				TriggerHandler.HandleAction (pickedItem.name, pickedItem.name == QueryEvent.query.voteResult, x, y);
			}

			actionHeld = true;
		}
		else
			actionHeld = false;
	}

	/*IEnumerator SwitchScene()
	{
		float time = 0.0f;
		Vector3 oldCoord = new Vector3(mCurrentRoom.x, mCurrentRoom.y, -10.0f);
		Vector3 newCoord = new Vector3(spawn.currentRoom.x, spawn.currentRoom.y, -10.0f);
		mCurrentRoom = spawn.currentRoom;
		while(time < 1.0f);
		{
			
			mainCamera.transform.position.y = Vector3.Lerp(oldCoord.y * spawn.mapOffset, newCoord.y * spawn.mapOffset, time);
			time += 0.1f;
			yield return null;
		}
	}*/
}
