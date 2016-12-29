using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class UnitTracker
{
	public static List<GameObject> AIUnits = new List<GameObject>();
	public static List<GameObject> playerUnits = new List<GameObject>();
	public static List<GameObject> playerBaseObjects = new List<GameObject>();

	public static void RegisterPlayerBaseObject(GameObject unit, bool add)
	{
		if (add)
			playerBaseObjects.Add(unit);
		else
			playerBaseObjects.Remove(unit);

		Debug.Log("UnitTracker - PlayerBaseObjects: " + playerBaseObjects.Count);
	}

	public static void RegisterPlayerUnit(GameObject unit, bool add)
	{
		if (add)
			playerUnits.Add(unit);
		else
			playerUnits.Remove(unit);

		//Debug.Log("UnitTracker - PlayerUnits: " + playerUnits.Count);
	}

	public static void RegisterAI(GameObject unit, bool add)
	{
		if (add)
			AIUnits.Add(unit);
		else
			AIUnits.Remove(unit);

		//Debug.Log("UnitTracker - AIUnits: " + AIUnits.Count);
	}
}
