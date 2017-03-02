using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class completeB : MonoBehaviour {
    public Texture completed;
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), completed);
        GUI.Button(new Rect(Screen.width / 2, Screen.height /1.5f, 150, 25), "Continue");
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
