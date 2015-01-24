using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Mover targetPlayer;
	public HealthSystem playerHP;
	float move = 1.0f;

	// Update is called once per frame
	void LateUpdate () 
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			//transform.position = new Vector2(transform.position.x, transform.position.y + move);
			targetPlayer.MoveOneSquare(transform.position.x, transform.position.y + move);
		}

		if(Input.GetKeyDown(KeyCode.S))
		{
			//transform.position = new Vector2(transform.position.x, transform.position.y - move);
			targetPlayer.MoveOneSquare(transform.position.x, transform.position.y - move);
		}

		if(Input.GetKeyDown(KeyCode.D))
		{
			//transform.position = new Vector2(transform.position.x + move, transform.position.y);
			targetPlayer.MoveOneSquare(transform.position.x + move, transform.position.y);
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			//transform.position = new Vector2(transform.position.x - move, transform.position.y);
			targetPlayer.MoveOneSquare(transform.position.x - move, transform.position.y);
		}
	}
}
