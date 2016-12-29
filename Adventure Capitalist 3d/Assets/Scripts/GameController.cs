using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private GameObject[] spawnPoints;

	// AI and player unitsRef
	private GameObject[] AI;
	private GameObject[] playerUnits;

	private GameObject[] playerBaseObjects;

	private GameObject knightObjRef;

	private float nextSpawnTime;
	private float timeBetweenSpawns;

	// Use this for initialization
	void Start ()
	{
		spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
		knightObjRef = (GameObject)Resources.Load("Models/Knight");

		timeBetweenSpawns = 2;
		nextSpawnTime = Time.time + timeBetweenSpawns;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Time.time > nextSpawnTime)
		{
			foreach(var spawnPoint in spawnPoints)
			{
				var randNumber = Random.Range(0, 15);

				if (randNumber == 0)
					GameObject.Instantiate(knightObjRef, spawnPoint.transform.position, spawnPoint.transform.rotation);
			}

			nextSpawnTime = Time.time + timeBetweenSpawns;
		}
	}


}
