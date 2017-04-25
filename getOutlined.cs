using UnityEngine;
using System.Collections;

public class getOutlined : MonoBehaviour {
	private Shader outline;
	private Shader normal;
	private Renderer rend;
	public GameObject Player;
	private RaycastHit hit;
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
		normal = Shader.Find("Standard");	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.SphereCast (Player.transform.position,0.5f, Player.transform.TransformDirection (Vector3.forward),out hit, 10f))
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