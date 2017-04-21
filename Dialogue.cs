using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour
{
	public Canvas GUICanvas;
	public Transform Player;

	void Start()
	{
		GUICanvas.gameObject.SetActive (false);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Player")
			GUICanvas.gameObject.SetActive(true);
	}

	void OnCollisionExit(Collision col)
	{
		if (col.collider.tag == "Player")
			GUICanvas.gameObject.SetActive (false);
	}

	void Update()
	{
		//GUICanvas.transform.LookAt (Player);
		Vector3 difference = Player.transform.position - GUICanvas.transform.position;
		float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
		GUICanvas.transform.rotation = Quaternion.Euler(0.0f,rotationY , 0.0f);		
	}
}
