using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CA MARCHE!!!!!!!!!!

public class Rewind : MonoBehaviour {

	public List <Vector3> positions;
	public bool isActive = false;
	public float Cooldown = 0.0f;
	public GameObject Character;
	public MaxRewind = 200;

	void Start() {
		Character = GameObject.FindGameObjectWithTag ("Player");
	}
	void FixedUpdate () {

		if (Cooldown > 0.0) {
			Cooldown -= Time.fixedDeltaTime;
		}

		if (Cooldown < 0)
			Cooldown = 0;

		if (Cooldown == 0) {
			if (isActive == false && positions.Count < MaxRewind) {
				positions.Add (Character.transform.position);

			} else if (isActive == false && positions.Count == MaxRewind) {
				positions.RemoveAt (0);
				positions.Add (Character.transform.position);
			}
		}
	}

	void Update (){

		if (Input.GetKeyDown (KeyCode.F)) {
			LaunchRewind (Character);
		}
	}

	public void LaunchRewind(GameObject charac){

		isActive = true;
		if (Cooldown == 0) {
			int i = 0;
			charac.transform.position = positions[i];

			positions.Clear ();
			isActive = false;
			Cooldown = 8.0f;
		}
	}

	void OnGUI(){
		GUI.Box (new Rect (Screen.width - 170, Screen.height - 70, 170, 25), "Rewind Cooldown : " + Cooldown.ToString ());		
	}
}
