using UnityEngine;
using System.Collections;

public class BasePlayerLifeScript : MonoBehaviour
{
	public int maxLife;
	public int currentHealth;

	// Use this for initialization
	void Start ()
	{
		UnitTracker.RegisterPlayerUnit(this.gameObject, true);
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		if (currentHealth <= 0)
		{
			UnitTracker.RegisterPlayerUnit(this.gameObject, false);
			GameObject.Destroy(gameObject);
		}
	}

	public bool Alive()
	{
		return currentHealth > 0;
	}
}
