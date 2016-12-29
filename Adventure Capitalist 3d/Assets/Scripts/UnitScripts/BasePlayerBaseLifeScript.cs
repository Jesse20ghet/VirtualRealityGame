using UnityEngine;
using System.Collections;

public class BasePlayerBaseLifeScript : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;

	// Use this for initialization
	void Start ()
	{
		UnitTracker.RegisterPlayerBaseObject(this.gameObject, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void TakeDamage(int amount)
	{
		currentHealth -= amount;

		if (currentHealth <= 0)
		{
			UnitTracker.RegisterPlayerBaseObject(this.gameObject, false);
			Destroy(this.gameObject);
		}
	}

	public bool Alive()
	{
		return currentHealth > 0;
	}
}
