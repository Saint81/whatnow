using UnityEngine;
using System.Collections;

public class DeathByWinning : MonoBehaviour {

	public Sprite[] bloodyMess;
	public Sprite LookDown;
	PlayerController controlEnd;
	HealthSystem systemEnd;

	int steps = 20;

	void Start()
	{
		controlEnd = GetComponent<PlayerController>();
		systemEnd = GetComponent<HealthSystem>();
	}
	
	// Update is called once per frame
	public IEnumerator Death () 
	{
		controlEnd.enabled = false;
		systemEnd.enabled = false;
		gameObject.GetComponent<SpriteRenderer>().sprite = LookDown;
		yield return new WaitForSeconds(2);
		for(int i = 0; i < steps; i++)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = bloodyMess[(i/6)%5];
			yield return null;
		}
		gameObject.GetComponent<SpriteRenderer>().sprite = bloodyMess[3];
		yield return new WaitForSeconds(5);
		QueryEvent.Get().Cleanup();
		Application.LoadLevel(3);
	}
}
