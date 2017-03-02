using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour {
    public Texture gameOverT;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverT);
        if (GUI.Button(new Rect(Screen.width/2,Screen.height/2,150,25),"Try again?"))
        {
            SceneManager.LoadScene("CraveSoutenance1");
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 25, 150, 25),"I'm over it"))
        {
            Application.Quit();
        }

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
