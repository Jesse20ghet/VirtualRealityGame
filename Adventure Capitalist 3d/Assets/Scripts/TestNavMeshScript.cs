using UnityEngine;
using System.Collections;

public class TestNavMeshScript : MonoBehaviour {

	NavMeshAgent agent;
	public GameObject target;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination(target.transform.position);
	}
}
