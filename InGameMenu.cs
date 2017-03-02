using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
    }
}
