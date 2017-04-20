using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour {

	public Transform Player;
	public Transform Head;
	Animator anim;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	public float rotSpeed = 0.8f;
	public float speed1 = 2.0f;
	public float speed2 = 5.0f;
	float accuracyWP = 7.0f;
	public float TimeToPatrol = 5.0f;

	// Use this for initialization

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 direction = Player.position - this.transform.position;
		float angle = Vector3.Angle (direction, Head.forward);
		direction.y = 0;

		if (state == "patrol" && waypoints.Length > 0) {

			if (anim.GetBool ("isIdle") == true) {
				anim.SetBool ("isIdle", false);
				anim.SetBool ("isWalking", true);
				TimeToPatrol = 0;
			}

			if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP){
				currentWP++;
				if(currentWP >= waypoints.Length)
					currentWP = 0;
				//currentWP = Random.Range (0, waypoints.Length);
			}

			//rotate towards waypoint
			direction = waypoints[currentWP].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed1);


		} 

		if (Vector3.Distance (Player.position, this.transform.position) < 10 && (angle < 30 || state == "pursuing")) {
			if (state != "pursuing") {
				anim.SetBool ("isIdle", false);
				anim.SetBool ("isWalking", false);
				anim.SetBool ("isRunning", true);
				state = "pursuing";
			}
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime * 3);
			/*if (direction.magnitude > 2) {
			transform.position += transform.forward * 5 * Time.deltaTime;
			anim.SetBool ("isRunning", true);
			} else {
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isRunning", false);
			}*/
			this.transform.Translate (0, 0, Time.deltaTime * speed2);
			TimeToPatrol = 7.0f;
			//anim.SetBool ("isAttacking", false);
		} 
		else {
			if (state != "slacking") {
				anim.SetBool ("isIdle", true);
				anim.SetBool ("isRunning", false);
				anim.SetBool ("isWalking", false);
				state = "slacking";
			}
			else
				TimeToPatrol -= Time.fixedDeltaTime;
			if (TimeToPatrol <= 0)
				state = "patrol";
		}
	}
}
