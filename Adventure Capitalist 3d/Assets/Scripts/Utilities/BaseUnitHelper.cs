using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utilities;

public class BaseUnitHelper
{
	//public void Register(GameObject gameObjectToRegister, Enumerations.UnitTypes type)
	//{
	//	switch(type)
	//	{
	//		case Enumerations.UnitTypes.PlayerUnit:
	//			UnitTracker.RegisterPlayerUnit(gameObjectToRegister, true);
	//			break;
	//		case Enumerations.UnitTypes.PlayerBase:
	//			UnitTracker.RegisterPlayerBaseObject(gameObjectToRegister, true);
	//			break;
	//		case Enumerations.UnitTypes.EnemyAI:
	//			UnitTracker.RegisterAI(gameObjectToRegister, true);
	//			break;
	//	}
	//}

	//public void UnRegister(GameObject gameObjectToRegister, Enumerations.UnitTypes type)
	//{
	//	switch (type)
	//	{
	//		case Enumerations.UnitTypes.PlayerUnit:
	//			UnitTracker.RegisterPlayerUnit(gameObjectToRegister, false);
	//			break;
	//		case Enumerations.UnitTypes.PlayerBase:
	//			UnitTracker.RegisterPlayerBaseObject(gameObjectToRegister, false);
	//			break;
	//		case Enumerations.UnitTypes.EnemyAI:
	//			UnitTracker.RegisterAI(gameObjectToRegister, false);
	//			break;
	//	}
	//}

	public GameObject FindClosestTarget(Vector3 currentPos, List<GameObject> possibleTargets)
	{
		GameObject targetToReturn = null;

		if (possibleTargets.Count > 0)
		{
			targetToReturn = possibleTargets[0];
			if (targetToReturn == null)
				return null;

			foreach (var playerBase in possibleTargets)
			{
				if (playerBase == null)
					continue;

				if (Vector3.Distance(currentPos, targetToReturn.transform.position) >
					Vector3.Distance(currentPos, playerBase.transform.position))
					targetToReturn = playerBase;
			}
		}

		return targetToReturn;
	}

	public GameObject FindRandomNewTarget(Vector3 currentPos, List<GameObject> targets)
	{
		GameObject targetToReturn = null;

		if(targets.Count > 0)
		{
			targetToReturn = targets[UnityEngine.Random.Range(0, targets.Count)];
		}

		return targetToReturn;
	}

	public bool IsUnitNearby(Vector3 currentPos, List<GameObject> units, float distance)
	{
		foreach (var unit in UnitTracker.playerUnits)
		{
			if (unit == null)
				continue;

			if (Vector3.Distance(unit.transform.position, currentPos) < distance)
				return true;
		}

		return false;
	}
}
