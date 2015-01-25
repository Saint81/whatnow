using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//position is the real position, while move is a representive on-screen position
	public Vector2 position;
	public Vector2 direction;
	public Mover targetPlayer;
	public HealthSystem playerHP;
	float move = 1.1f;

	public LevelParser levelparser;
	public TileType[,] map;

	public static bool isWaitingForAudience;
	
	void Start()
	{
		map = levelparser.ParseLevel ("test.txt");
<<<<<<< HEAD
		QueryEvent.query = new QueryEvent();
		QueryEvent.query.Activate(10.0f, levelparser.lActiveItems);
=======
		direction = new Vector2(0.0f, 1.0f);
>>>>>>> origin/master
	}

	// Update is called once per frame
	void LateUpdate () 
	{
<<<<<<< HEAD
		if( QueryEvent.query.IsActive() )
		{
			QueryEvent.query.Update();
			return;
		}

		if(Input.GetKeyDown(KeyCode.W))
=======
		if(Input.GetKey(KeyCode.W))
>>>>>>> origin/master
		{
			direction = new Vector2(0.0f, 1.0f);
			if(position.y - 1 >= 0 && !targetPlayer.isMoving)
			{
				if(map[(int)position.y - 1,(int)position.x] == TileType.EMPTY)
				{
					StartCoroutine( targetPlayer.MoveOneSquare(transform.position.x, transform.position.y, direction));
					position.y -= 1;
				}
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
			}
		}

		//if(Input.GetKey
	}
}
