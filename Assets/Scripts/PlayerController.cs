using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//position is the real position, while move is a representive on-screen position
	public Vector2 position;
	public Vector2 direction;
	public Mover targetPlayer;
	public HealthSystem playerHP;
	float move = 1.1f;
	public MapSpawnerScript spawn;
	public LevelParser levelparser;
	public TileType[,] map;
	
	void Start()
	{

		map = levelparser.ParseLevel (spawn.getCurrentRoomMap());

		direction = new Vector2(0.0f, 1.0f);
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		if(Input.GetKey(KeyCode.W))
		{
			direction = new Vector2(0.0f, 1.0f);
			if(position.y - 1 >= 0 && !targetPlayer.isMoving)
			{
				if(map[(int)position.y - 1,(int)position.x] == TileType.EMPTY)
				{
					StartCoroutine( targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
					position.y -= 1;
				}
			}else if((position.x <= 10 && position.x >= 7) && position.y == 0 && !targetPlayer.isMoving)
			{
				//create a new room
				spawn.moveRoom(dir.UP);
				string newMap = spawn.getCurrentRoomMap();
				map = levelparser.ParseLevel(newMap);
				StartCoroutine(targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
				position.y = 17;

			}
		}

		if(Input.GetKey(KeyCode.S))
		{
			direction = new Vector2(0.0f, -1.0f);
			if(position.y + 1 < map.GetLength(0) && !targetPlayer.isMoving)
			{
				if(map[(int)position.y + 1,(int)position.x] == TileType.EMPTY)
				{
					StartCoroutine( targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
					position.y += 1;
				}
			}else if((position.x <= 10 && position.x >= 7) && position.y == 17 && !targetPlayer.isMoving)
			{
				//create a new room
				spawn.moveRoom(dir.DOWN);
				string newMap = spawn.getCurrentRoomMap();
				map = levelparser.ParseLevel(newMap);
				StartCoroutine(targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
				position.y = 0;
				
			}
		}

		if(Input.GetKey(KeyCode.D))
		{
			direction = new Vector2(1.0f, 0.0f);
			if(position.x + 1 < map.GetLength(1) && !targetPlayer.isMoving)
			{
				if(map[(int)position.y,(int)position.x + 1] == TileType.EMPTY)
				{
					StartCoroutine( targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
					position.x += 1;
				}
			}else if((position.y <= 10 && position.y >= 7) && position.x == 17 && !targetPlayer.isMoving)
			{
				//create a new room
				spawn.moveRoom(dir.RIGHT);
				string newMap = spawn.getCurrentRoomMap();
				map = levelparser.ParseLevel(newMap);
				StartCoroutine(targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
				position.x = 0;
				
			}
		}

		if(Input.GetKey(KeyCode.A))
		{
			direction = new Vector2(-1.0f, 0.0f);
			if(position.x - 1 >= 0 && !targetPlayer.isMoving)
			{
				if(map[(int)position.y,(int)position.x - 1] == TileType.EMPTY)
				{
					StartCoroutine( targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
					position.x -= 1;
				}
			}else if((position.y <= 10 && position.y >= 7) && position.x == 0 && !targetPlayer.isMoving)
			{
				//create a new room
				spawn.moveRoom(dir.LEFT);
				string newMap = spawn.getCurrentRoomMap();
				map = levelparser.ParseLevel(newMap);
				StartCoroutine(targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
				position.x = 17;
				
			}
		}

		//if(Input.GetKey
	}
}
