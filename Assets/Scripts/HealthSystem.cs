using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public int HP = 100;
	public int Hunger = 100;
	public int stools = 0;
	public int sweapons = 0;
	public int mtools = 10;
	public int mweapons = 10;
	public DeathByHealthIsZero dying;

	bool winCondActive = false;
	DeathByWinning explode;
	WinTrigger winTrig;

	void Start()
	{
		explode = GetComponent<DeathByWinning>();
		winTrig = GetComponent<WinTrigger>();
	}

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

		if((stools == mtools && sweapons == mweapons) && !winCondActive)
		{
			winCondActive = true;
			explode.enabled = true;
			winTrig.enabled = true;
		}
	}
}
