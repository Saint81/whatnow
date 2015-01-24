using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public bool isMoving = false;
	int steps = 20;
	float move = 0.32f;

	public IEnumerator MoveOneSquare (float x, float y, Vector2 direction) 
	{
		isMoving = true;
		float newX = (move/steps * direction.x);
		float newY = (move/steps * direction.y);
		//transform.position = new Vector2 (x, y);
		for(int i = 0; i < steps; i++)
		{
			transform.position = new Vector3 ((newX + x), (newY + y), -1.0f);
			x += newX;
			y += newY;
			yield return null;
		}
		isMoving = false;
	}
}
