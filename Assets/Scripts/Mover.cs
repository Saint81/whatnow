using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public bool isMoving = false;
	float move = 1.1f;

	public IEnumerator MoveOneSquare (float x, float y, Vector2 direction) 
	{
		isMoving = true;
		float newX = (move/5 * direction.x);
		float newY = (move/5 * direction.y);
		//transform.position = new Vector2 (x, y);
		for(int i = 0; i < 5; i++)
		{
			transform.position = new Vector2 ((newX + x), (newY + y));
			x += newX;
			y += newY;
			yield return null;
		}
		isMoving = false;
	}
}
