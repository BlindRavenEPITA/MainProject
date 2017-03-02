using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour {

	public List <Vector3> positions;
	public bool isActive = false;
	public float Cooldown = 0.0f;
	public GameObject Character;

	void Start() {
		Character = GameObject.FindGameObjectWithTag ("Player");
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Cooldown > 0.0) {
			Cooldown -= Time.fixedDeltaTime;
		}

		if (Cooldown < 0)
			Cooldown = 0;
	}

	void Update (){

		if (Input.GetKeyDown (KeyCode.F)) {
			LaunchRewind (Character);
		} else {
			if (isActive == false && positions.Count < 100) {
				positions.Add (Character.transform.position);

			} else if (isActive == false && positions.Count == 100) {
				positions.RemoveAt (0);
				positions.Add (Character.transform.position);
			}
		}
	}

	public void LaunchRewind(GameObject charac){

		isActive = true;
		if (Cooldown <= 0) {
			int i = positions.Count - 1;
			charac.transform.position = positions[i];

			positions.Clear ();
			isActive = false;
			Cooldown = 8.0f;
		}
	}

	void OnGUI(){
		GUI.Box (new Rect (Screen.width - 150, Screen.height - 50, 75, 25), Cooldown.ToString ());		
	}
}

