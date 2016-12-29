using UnityEngine;
using System.Collections;

public class PlayerMouseScript : MonoBehaviour {

	private GameObject cube;
	private GameObject archer;

	// Use this for initialization
	void Start ()
	{
		cube = (GameObject)Resources.Load("Models/Cube");
		archer = (GameObject)Resources.Load("Models/Archer");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Ray ray = new Ray();
			RaycastHit hit = new RaycastHit();
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log(hit.collider.name);
				if (hit.collider.tag == "AI")
					hit.transform.gameObject.SendMessage("TakeDamage", 10000);
			}
		}
		else if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			Ray ray = new Ray();
			RaycastHit hit = new RaycastHit();
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log(hit.collider.name);
				if (hit.collider.name == "Plane")
				{

					Instantiate(cube, hit.point, Quaternion.identity);
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Ray ray = new Ray();
			RaycastHit hit = new RaycastHit();
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log(hit.collider.name);
				if (hit.collider.name == "Plane")
				{

					Instantiate(archer, hit.point, Quaternion.identity);
				}
			}
		}



	}
}
