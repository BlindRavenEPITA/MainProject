using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour {

	public List <float> positions;
	public bool isActive = false;
	public float Cooldown = 0.0f;
	public GameObject Character;

	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.F) && Character.tag == "Player")
			LaunchRewind (Character);
		
		if (Cooldown > 0.0) {
			Cooldown -= Time.fixedDeltaTime;
		}
	}

	void Update (){
		
		if (isActive == false && positions.Count < 150) {
			positions.Add (Character.transform.position.x);
			positions.Add (Character.transform.position.y);
			positions.Add (Character.transform.position.z);

		} else if (isActive == false && positions.Count == 150) {

			for (int i = 0; i < 3; i++)
				positions.RemoveAt (0);

			positions.Add (Character.transform.position.x);
			positions.Add (Character.transform.position.y);
			positions.Add (Character.transform.position.z);
		}
	}

	public void LaunchRewind(GameObject charac){

		isActive = true;

		for (int i = 0; i < positions.Count; i += 3) {
			float a = positions [i];
			float b = positions [i + 1];
			float c = positions [i + 2];
			charac.transform.position = new Vector3( a, b, c);
		
		}

		positions.Clear ();
		isActive = false;
		Cooldown = 8.0f;
	}
}
