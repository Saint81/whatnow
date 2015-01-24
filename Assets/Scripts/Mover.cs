using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	float move = 1.0f;

	public void MoveOneSquare (float x, float y) 
	{
		transform.position = new Vector2 (x, y);
	}
}
