using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MindControl : MonoBehaviour {
	RaycastHit hit;
	public GameObject cam;
	GameObject Touched;
	public float ToNormal = 20.0f;
	public float CoolD = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && CoolD <= 0) {
			if (Physics.Raycast (cam.transform.position, cam.transform.TransformDirection (Vector3.forward), out hit, 17.0f)) {
				Touched = hit.collider.gameObject;
				if (Touched.tag == "enemy") {
					CoolD = 15.0f;
					Touched.GetComponent<NavMeshAgent> ().speed = 0;
					if (Touched.name.Contains ("Exo_Gray")) {
						Touched.GetComponent<AIPatrol> ().ToNormal = 19.5f;
						Touched.GetComponent<Animator> ().SetBool ("isCon", true);
					} 
					else {
						Touched.GetComponent<AIStand> ().ToNormal = 20.0f;
						Touched.GetComponent<Animator> ().SetBool ("isCon", true);
					}
				}
			}
		} 
		else {
			if (CoolD > 0)
				CoolD -= Time.fixedDeltaTime;
		}
	}
}
