using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour {

	public Transform Player;
	public Transform Head;
	Animator anim;
	RaycastHit seen;
	public NavMeshAgent MyNav;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	public float rotSpeed = 0.9f;
	public float speed1 = 2.0f;
	public float speed2 = 5.0f;
	float accuracyWP = 2.0f;
	public float TimeToPatrol = 7.5f;
	public float TimeToSlack = 4.0f;
	public float ToNormal = 0.0f;


	void Start () {
		anim = GetComponent<Animator> ();
		MyNav = GetComponent<NavMeshAgent>();
	}
	
	void Update () {

		Vector3 direction = Player.position - this.transform.position;
		float angle = Vector3.Angle (direction, Head.forward);
		direction.y = 0;

		if (!anim.GetBool("isCon")) {
			transform.GetChild (2).GetComponent<ParticleSystem>().Stop();
			if (state == "patrol" && waypoints.Length > 0) {

				if (anim.GetBool ("isIdle") == true) {
					anim.SetBool ("isIdle", false);
					anim.SetBool ("isWalking", true);
					TimeToPatrol = 0;
				}

				if (Vector3.Distance (waypoints [currentWP].transform.position, transform.position) < accuracyWP) {
					currentWP++;
					if (currentWP >= waypoints.Length)
						currentWP = 0;
				}

				MyNav.speed = speed1;
				MyNav.SetDestination (waypoints [currentWP].transform.position);



			} 
			if (Vector3.Distance (Player.position, this.transform.position) < 12 && (angle < 30 || state == "pursuing")) {

				if (state != "pursuing") {
					anim.SetBool ("isIdle", false);
					anim.SetBool ("isWalking", false);
					anim.SetBool ("isRunning", true);
					state = "pursuing";
				}
				Head.transform.forward = direction;
				MyNav.speed = speed2;
				MyNav.SetDestination (Player.transform.position);
				TimeToPatrol = 7.5f;
			
			} else {
				if (state != "slacking") {
					anim.SetBool ("isIdle", true);
					anim.SetBool ("isRunning", false);
					anim.SetBool ("isWalking", false);
					state = "slacking";
				} else {
					TimeToPatrol -= Time.fixedDeltaTime;
					MyNav.speed = 0;
				}
				if (TimeToPatrol <= 0)
					state = "patrol";
			}
		} else {
			if(anim.GetBool("isRunning") || anim.GetBool("isIdle") || anim.GetBool("isWalking")){
				anim.SetBool ("isRunning", false);
				anim.SetBool ("isIdle", false);
				anim.SetBool ("isWalking", false);
				anim.SetBool("isCon", true);
				MyNav.SetDestination (waypoints [currentWP].transform.position);			
				MyNav.speed = 0;

				transform.GetChild (2).GetComponent<ParticleSystem>().Play();
			}
			if (ToNormal > 0) {
				ToNormal -= Time.deltaTime;
			} else {
				anim.SetBool ("isCon", false);
				anim.SetBool ("isIdle", true);
				state = "patrol";
			}
		}
	}
}
