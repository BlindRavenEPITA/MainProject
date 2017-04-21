using UnityEngine;
using System.Collections;

public class getOutlined : MonoBehaviour {
	private Shader outline;
	private Shader normal;
	private Renderer rend;
	private GameObject Player;
	private RaycastHit hit;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		outline = Shader.Find("Custom/NewSurfaceShader");
		normal = Shader.Find("Standard");
		Player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (Player.transform.position, Player.transform.TransformDirection (Vector3.forward),out hit, 10f)) 
		{
			if (hit.collider.gameObject == this.gameObject)
				rend.material.shader = outline;
			else
				rend.material.shader = normal;
		}
		else
			rend.material.shader = normal;
	}
}