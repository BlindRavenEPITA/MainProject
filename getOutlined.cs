using UnityEngine;
using System.Collections;

public class getOutlined : MonoBehaviour {
	private Shader outline;
	private Shader normal;
	private Renderer rend;
	public GameObject Player;
	private RaycastHit hit;
	float visible = 2.0f;

	// Use this for initialization
	void Start () {
		try
		{
			rend= transform.GetChild (0).transform.GetChild (6).GetComponent<Renderer>();
		}
		catch
		{
			rend = GetComponent<Renderer>();
		}

		outline = Shader.Find("Custom/NewSurfaceShader");
		normal = Shader.Find("Standard");
		rend.material.shader = normal;

		//Player = GameObject.FindWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {

		if (Physics.Raycast (Player.transform.position, Player.transform.TransformDirection (Vector3.forward), out hit, 15.0f)) {

			if (hit.collider.gameObject == gameObject) {
				rend.material.shader = outline;
				visible = 2.0f;
			} 

			else if (visible > 0)
				visible -= Time.deltaTime;

			else {
				rend.material.shader = normal;
				visible = 0;
			}
		} 

		else if (visible > 0)
			visible -= Time.deltaTime;

		else {
			visible = 0;
			rend.material.shader = normal;
		}
	}
}
