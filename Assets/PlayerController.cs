using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	float move = 1.0f;

	// Update is called once per frame
	void LateUpdate () 
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			transform.position = new Vector2(transform.position.x, transform.position.y + move);
		}

		if(Input.GetKeyDown(KeyCode.S))
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - move);
		}

		if(Input.GetKeyDown(KeyCode.D))
		{
			transform.position = new Vector2(transform.position.x + move, transform.position.y);
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			transform.position = new Vector2(transform.position.x - move, transform.position.y);
		}
	}
}
