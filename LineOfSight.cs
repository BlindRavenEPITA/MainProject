using UnityEngine;
using System.Collections;

public class LineOfSight : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (Vector3.Distance(transform.position, player.transform.position) <= 10)
        {
            transform.position += transform.forward * 5 * Time.deltaTime;
        }
    }
}