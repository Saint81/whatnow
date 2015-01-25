using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public bool isMoving = false;
	public Sprite[] walkAnim;
	public Sprite[] walkSideAnim;
	public Sprite[] walkUpAnim;
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
			if(direction.x == 0.0f && direction.y == -1.0f)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = walkAnim[(i/3)%6];
			}
			
			if(direction.x == 0.0f && direction.y == 1.0f)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = walkUpAnim[(i/3)%6];
			}
			
			if(direction.x == 1.0f && direction.y == 0.0f)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = walkSideAnim[(i/3)%6];
				transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
			}
			
			if(direction.x == -1.0f && direction.y == 0.0f)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = walkSideAnim[(i/3)%6];
				transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			}

			transform.position = new Vector3 ((newX + x), (newY + y), -1.0f);
			x += newX;
			y += newY;
			yield return null;
		}
		isMoving = false;
	}
}
