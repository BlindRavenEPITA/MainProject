using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IsItOver : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == player)
            SceneManager.LoadScene("gameOver");

    }
	// Update is called once per frame
	void Update () {

    }
}
