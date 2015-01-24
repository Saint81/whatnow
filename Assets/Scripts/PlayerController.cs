using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//position is the real position, while move is a representive on-screen position
	public Vector2 position;
	public Mover targetPlayer;
	public HealthSystem playerHP;
	float move = 1.1f;

	public LevelParser levelparser;
	public TileType[,] map;
	
	void Start()
	{
		map = levelparser.ParseLevel ("test.txt");
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			if(position.y - 1 >= 0)
			{
				if(map[(int)position.y - 1,(int)position.x] == TileType.EMPTY)
				{
					targetPlayer.MoveOneSquare(transform.position.x, transform.position.y + move);
					position.y -= 1;
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.S))
		{
			if(position.y + 1 < map.GetLength(0))
			{
				if(map[(int)position.y + 1,(int)position.x] == TileType.EMPTY)
				{
					targetPlayer.MoveOneSquare(transform.position.x, transform.position.y - move);
					position.y += 1;
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.D))
		{
			if(position.x + 1 < map.GetLength(1))
			{
				if(map[(int)position.y,(int)position.x + 1] == TileType.EMPTY)
				{
					targetPlayer.MoveOneSquare(transform.position.x + move, transform.position.y);
					position.x += 1;
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			if(position.x - 1 >= 0)
			{
				if(map[(int)position.y,(int)position.x - 1] == TileType.EMPTY)
				{
					targetPlayer.MoveOneSquare(transform.position.x - move, transform.position.y);
					position.x -= 1;
				}
			}
		}

		//if(Input.GetKey
	}
}
