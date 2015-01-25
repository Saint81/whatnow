using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public int HP = 100;
	public int Hunger = 100;
	public int stools = 0;
	public int sweapons = 0;
	public int mtools = 10;
	public int mweapons = 10;
	//public DeathByWinning explode;
	public DeathByHealthIsZero dying;

	public void ModifyHealth(int damage)
	{
		HP -= damage;
	}

	void Update()
	{
		if(HP <= 0)
		{
			//Destroy(this.gameObject);
			StartCoroutine(dying.Death());
		}
	}
}
