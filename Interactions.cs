using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour {
	public GameObject Character;
	public GameObject[] Interactables;
	public Vector3 interactSphere;
	public float Radius;


	// Use this for initialization
	void Start () {
		Character = GameObject.FindGameObjectWithTag ("Player");
		Interactables = GameObject.FindGameObjectsWithTag ("Interactable");
		interactSphere = (Character.transform.position);
		Radius = 10.0f;
	}
	
	void InteractionPossible(){
		
		Collider[] hitColliders = Physics.OverlapSphere(interactSphere, Radius);
		foreach (Collider Inter in hitColliders) {
			if (Inter.gameObject.tag == "Interactable") {
				SceneManager.LoadScene("LevelComplete");
			}
		}
	}
}
