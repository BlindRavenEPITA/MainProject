using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public string Destination;

    IEnumerator FadeToDestinationLevel()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Player").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(Destination);
    }


    void OnCollisionEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            StartCoroutine(FadeToDestinationLevel());
        }
    }
}
