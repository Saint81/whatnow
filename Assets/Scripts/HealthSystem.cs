using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public int HP = 100;

	public void ModifyHealth(int damage)
	{
		HP -= damage;
	}

	void Update()
	{
		if(HP <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
