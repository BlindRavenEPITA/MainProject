using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class opening : MonoBehaviour {
    public MovieTexture myMovie;
    // Use this for initialization
    void Start()
    {
        myMovie.Play();
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), myMovie);
    }
    void Update()
    {
        if (!myMovie.isPlaying)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
