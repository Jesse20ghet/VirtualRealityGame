using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Utilities;

public class PlayerAIMeleeScript : MonoBehaviour
{
	private BaseUnitHelper baseUnitHelper = new BaseUnitHelper();

	private GameObject target;
	private GameObject homeBase;

	private int NEARBY_DISTANCE = 5;

	private int health = 100;
	private bool returningToBase = false;

	private float timeUntilNextAttack;
	private float timeBetweenAttacks;

	// Use this for initialization
	void Start ()
	{
		target = baseUnitHelper.FindRandomNewTarget(transform.position, UnitTracker.AIUnits);
		homeBase = GameObject.Find("HomeBase");
		
		timeBetweenAttacks = 1F;
		timeUntilNextAttack = Time.time + timeBetweenAttacks;
	}

	// Update is called once per frame
	void Update ()
	{
		if (UnitTracker.AIUnits.Count == 0)
		{
			transform.position = Vector3.MoveTowards(transform.position, homeBase.transform.position, 2 * Time.deltaTime);
			transform.LookAt(homeBase.transform.position);
		}
		else
		{
			if (target == null || (target.GetComponent<BaseEnemyLifeScript>() != null && !target.GetComponent<BaseEnemyLifeScript>().Alive()))
				target = baseUnitHelper.FindRandomNewTarget(transform.position, UnitTracker.AIUnits);

			if (baseUnitHelper.IsUnitNearby(transform.position, UnitTracker.AIUnits, NEARBY_DISTANCE))
				target = baseUnitHelper.FindClosestTarget(transform.position, UnitTracker.AIUnits);

			if (Vector3.Distance(target.transform.position, transform.position) > 1)
			{
				transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime);
			}
			else
			{
				if (timeUntilNextAttack < Time.time)
				{
					timeUntilNextAttack = Time.time + timeBetweenAttacks;
					target.SendMessage("TakeDamage", 10);
				}

			}
			transform.LookAt(target.transform.position);
		}
	}
}
