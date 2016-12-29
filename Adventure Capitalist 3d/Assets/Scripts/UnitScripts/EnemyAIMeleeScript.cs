using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyAIMeleeScript : MonoBehaviour {
	private BaseUnitHelper baseUnitHelper = new BaseUnitHelper();

	private GameObject target;

	private Collider collider;
	private Animator animator;
	private Animation attackAnimation;

	private NavMeshAgent agent;

	private float timeUntilNextAttack;
	private float timeBetweenAttacks;

	private float NEARBY_DISTANCE = 5;

	private int health;

	// Use this for initialization
	void Start ()
	{
		var possibleTargets = new List<GameObject>();
		possibleTargets.AddRange(UnitTracker.playerUnits);
		possibleTargets.AddRange(UnitTracker.playerBaseObjects);
		target = baseUnitHelper.FindRandomNewTarget(transform.position, possibleTargets);

		animator = GetComponent<Animator>();
		collider = GetComponent<Collider>();
		agent = GetComponent<NavMeshAgent>();
		agent.avoidancePriority = UnityEngine.Random.Range(0, 100);
		 
		timeBetweenAttacks = 1.134F;
		timeUntilNextAttack = Time.time + timeBetweenAttacks;

		health = 150;
	}

	// Update is called once per frame
	void Update ()
	{
		if (health <= 0)
			return;

		if (target == null)
		{
			var possibleTargets = new List<GameObject>();
			possibleTargets.AddRange(UnitTracker.playerUnits);
			possibleTargets.AddRange(UnitTracker.playerBaseObjects);
			target = baseUnitHelper.FindClosestTarget(transform.position, possibleTargets);
		}

		if (baseUnitHelper.IsUnitNearby(transform.position, UnitTracker.playerUnits, NEARBY_DISTANCE))
			target = baseUnitHelper.FindClosestTarget(transform.position, UnitTracker.playerUnits);

		if (Vector3.Distance(target.transform.position, transform.position) > 2)
		{
			//transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime);
			agent.SetDestination(target.transform.position);
			animator.SetBool("Running", true);
			animator.SetBool("Attack", false);
		}
		else
		{
			animator.SetBool("Running", false);
			animator.SetBool("Attack", true);
			transform.LookAt(target.transform.position);

			if(animator.GetCurrentAnimatorStateInfo(0).IsName("Melee_Attack") && timeUntilNextAttack < Time.time)
			{
				Debug.Log("animation: Attacking");
				timeUntilNextAttack = Time.time + timeBetweenAttacks;
				target.SendMessage("TakeDamage", 5);
			}
		}
	}
	
	private void TakeDamage(int amount)
	{
		health -= amount;

		if(health <= 0)
		{


			UnitTracker.RegisterAI(this.gameObject, false);

			Destroy(collider);
			Destroy(this, 2);
		}
	}

	public bool Alive()
	{
		return health > 0;
	}

}
