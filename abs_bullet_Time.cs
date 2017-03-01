using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abs_bullet_Time : MonoBehaviour {
	public float minTimeScale = 0.5f;
	public float transitionSpeed = 1.0f;
	GameObject player;

	bool isBulletTime = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			isBulletTime = !isBulletTime;

			StopCoroutine ("ToggleBulletTime");
			StartCoroutine ("ToggleBulletTime");


			/*player.GetComponent ("Character Motor (Script)").GetComponent ("Max Forward Speed") = player.GetComponent ("Character Motor (Script)").GetComponent ("Max Forward Speed") / Time.timeScale;
			player.GetComponent ("Character Motor (Script)").GetComponent ("Max Sideways Speed") = player.GetComponent ("Character Motor (Script)").GetComponent ("Max Sideways Speed") / Time.timeScale;
			player.GetComponent ("Character Motor (Script)").GetComponent ("Max Backwards Speed") = player.GetComponent ("Character Motor (Script)").GetComponent ("Max Backwards Speed") / Time.timeScale;*/
		}
	}

	IEnumerator ToggleBulletTime (){
		float t = 0.0f;
		float startScale = Time.timeScale;
		float targetScale = isBulletTime ? minTimeScale : 1;
		float lastTick = Time.realtimeSinceStartup;

		while (t <= 1.0f) {
			t += (Time.realtimeSinceStartup - lastTick) * (1.0f / transitionSpeed);
			lastTick = Time.realtimeSinceStartup;
			Time.timeScale = Mathf.Lerp (startScale, targetScale, t);
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			yield return new WaitForSeconds (.1f);
		}
	}

	void OnGUI(){
		GUI.Box (new Rect (Screen.width - 150, Screen.height - 50, 75, 25), Time.timeScale.ToString ());
	}
}
