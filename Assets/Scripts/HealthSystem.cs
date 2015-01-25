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
	private float oldtime = 0;
	private float newtime;

	void Update()
	{
		newtime = Time.time;
		if(newtime - oldtime > 5){
			Hunger--;
			oldtime = newtime;
		}
		if(HP <= 0 || Hunger <=0)
		{
			//Destroy(this.gameObject);
			StartCoroutine(dying.Death());
		}
		if(HP > 100)
			HP = 100;
		if(Hunger > 100)
			Hunger = 100;
		if(stools > mtools)
			stools = mtools;
		if(sweapons > mweapons)
			sweapons = mweapons;
	}
}
