using UnityEngine;
using System.Collections;

public class DeathByHealthIsZero : MonoBehaviour {
	
	PlayerController controlEnd;
	HealthSystem systemEnd;

	//public Sprite[] spinAround;
	public Sprite lookDown;
	public Sprite[] deathAnim;

	//int spins = 60;
	int steps = 19;
	// Use this for initialization
	void Start () 
	{
		controlEnd = GetComponent<PlayerController>();
		systemEnd = GetComponent<HealthSystem>();
	}
	
	// Update is called once per frame
	public IEnumerator Death () 
	{
		controlEnd.enabled = false;
		systemEnd.enabled = false;
		/*for(int i = 0; i < spins; i++)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = spinAround[(i)%4];
			yield return null;
		}*/
		gameObject.GetComponent<SpriteRenderer>().sprite = lookDown;
		yield return new WaitForSeconds(1);
		for(int i = 0; i < steps; i++)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = deathAnim[(i/2)%10];
			yield return null;
		}
		gameObject.GetComponent<SpriteRenderer>().sprite = deathAnim[9];
		yield return new WaitForSeconds(5);
		Application.LoadLevel(2);
	}
}

