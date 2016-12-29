using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Utilities;

public class PlayerAIArcherScript : MonoBehaviour
{
	private BaseUnitHelper baseUnitHelper = new BaseUnitHelper();

	private GameObject target;
	private GameObject homeBase;

	private Animator animator;
	private NavMeshAgent agent;

	private int NEARBY_DISTANCE = 10;

	private int health = 100;
	private bool returningToBase = false;

	private float timeUntilNextAttack;
	private float timeBetweenAttacks;

	// Use this for initialization
	void Start ()
	{
		target = baseUnitHelper.FindRandomNewTarget(transform.position, UnitTracker.AIUnits);
		homeBase = GameObject.Find("HomeBase");

		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();

		timeBetweenAttacks = 2F;
		//timeUntilNextAttack = Time.time + timeBetweenAttacks;
	}

	// Update is called once per frame
	void Update ()
	{
		if (UnitTracker.AIUnits.Count == 0)
		{
			animator.SetBool("Running", true);
			animator.SetBool("Attacking", false);
			agent.SetDestination(homeBase.transform.position);
		}
		else
		{
			if (target == null || (target.GetComponent<BaseEnemyLifeScript>() != null && !target.GetComponent<BaseEnemyLifeScript>().Alive()))
				target = baseUnitHelper.FindRandomNewTarget(transform.position, UnitTracker.AIUnits);

			if (baseUnitHelper.IsUnitNearby(transform.position, UnitTracker.AIUnits, NEARBY_DISTANCE))
				target = baseUnitHelper.FindClosestTarget(transform.position, UnitTracker.AIUnits);

			if (Vector3.Distance(target.transform.position, transform.position) > 10)
			{
				animator.SetBool("Running", true);
				animator.SetBool("Attacking", false);
				//transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime);
				agent.SetDestination(target.transform.position);
			}
			else
			{
				transform.LookAt(target.transform.position);

				if (timeUntilNextAttack < Time.time)
				{
					timeUntilNextAttack = Time.time + timeBetweenAttacks;
					target.SendMessage("TakeDamage", 20);
					animator.SetBool("Running", false);
					animator.SetBool("Attacking", true);
					agent.Stop();
				}

			}
		}
	}
}
