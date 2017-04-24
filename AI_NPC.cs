using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NPC: MonoBehaviour {

	Animator anim;

	public GameObject[] waypoints;
	int currentWP = 0;
	public float rotSpeed = 0.9f;
	public float speed = 1.5f;
	float accuracyWP = 2.0f;

	// Use this for initialization

	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 direction;
		if (waypoints.Length > 0) {

			if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP){
				currentWP = Random.Range (0, waypoints.Length);
			}

			//rotate towards waypoint
			direction = waypoints[currentWP].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed);
		} 
	}
}
