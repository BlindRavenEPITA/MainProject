using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterRoomInMap : MonoBehaviour
{
    public GameObject Destination;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player entered " + Destination);
            other.transform.position = Destination.transform.position;
        }
    }
}