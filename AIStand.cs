using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStand : MonoBehaviour {

	public Transform Player;
	public Transform Head;
	Animator anim;
	public NavMeshAgent MyNav;

	string state = "Back";
	public GameObject post;
	public float rotSpeed = 1f;
	public float speed1 = 2.0f;
	public float speed2 = 5.0f;
	float accuracyWP = 2.0f;
	public float TimeToPatrol = 7.0f;
	Vector3 forw;
	public float ToNormal = 5.0f;


	void Start () {
		anim = GetComponent<Animator> ();
		forw = transform.forward;
		MyNav = GetComponent<NavMeshAgent> ();
	}

	void Update () {

		Vector3 direction = Player.position - this.transform.position;
		float angle = Vector3.Angle (direction, Head.forward);
		direction.y = 0;

		if (!anim.GetBool ("isCon")) {

			transform.GetChild (2).GetComponent<ParticleSystem>().Stop();

			if (state == "Back") {

				if (Vector3.Distance (post.transform.position, transform.position) > accuracyWP) {
					if (anim.GetBool ("isIdle") || anim.GetBool("isCon")) {
						anim.SetBool ("isCon", false);
						anim.SetBool ("isIdle", false);
						anim.SetBool ("isWalking", true);
						TimeToPatrol = 0;
					}
						
					MyNav.SetDestination (post.transform.position);
					MyNav.speed = speed1;

				} else {
					if (anim.GetBool ("isWalking")) {
						anim.SetBool ("isWalking", false);
						anim.SetBool ("isIdle", true);
					}
					transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (forw), rotSpeed * Time.deltaTime * 5);
				}
			} 

			if (Vector3.Distance (Player.position, this.transform.position) < 10 && (angle < 30 || state == "pursuing")) {
				if (state != "pursuing") {
					anim.SetBool ("isIdle", false);
					anim.SetBool ("isWalking", false);
					anim.SetBool ("isCon", false);
					anim.SetBool ("isRunning", true);
					state = "pursuing";
				}
				Head.transform.forward = direction;
				MyNav.SetDestination (Player.transform.position);
				MyNav.speed = speed2;
				TimeToPatrol = 13.0f;

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
					state = "Back";
			}
		} else {
			if(anim.GetBool("isRunning") || anim.GetBool("isIdle") || anim.GetBool("isWalking")){
				anim.SetBool ("isRunning", false);
				anim.SetBool ("isIdle", false);
				anim.SetBool ("isWalking", false);
				anim.SetBool("isCon", true);
				transform.GetChild (2).GetComponent<ParticleSystem>().Play();
			}
			if (ToNormal > 0) {
				MyNav.speed = 0;
				ToNormal -= Time.deltaTime;
			}else {
				anim.SetBool ("isCon", false);
				anim.SetBool ("isWalking", true);
			}
		}
	}
}

