using UnityEngine;
using System.Collections;

public class BaseEnemyLifeScript : MonoBehaviour
{
	public int maxHealth;
	public int currentHealth;

	private Animator animator;

	// Use this for initialization
	void Start()
	{
		UnitTracker.RegisterAI(this.gameObject, true);
		animator = GetComponent<Animator>();
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		if (currentHealth <= 0)
		{
			animator.SetBool("Death", true);
			animator.SetBool("Running", false);
			animator.SetBool("Attack", false);

			UnitTracker.RegisterAI(this.gameObject, false);

			GetComponent<NavMeshAgent>().enabled = false;

			MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
			foreach(var script in scripts)
			{
				if(script != this)
					script.enabled = false;
			}
			Destroy(this);
		}
	}

	public bool Alive()
	{
		return currentHealth > 0;
	}
}