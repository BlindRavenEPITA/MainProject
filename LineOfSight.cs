using UnityEngine;
using System.Collections;

public class LineOfSight : MonoBehaviour {
    RaycastHit hit;
    public GameObject player;
    public Transform ennemy;
    Vector3 Direction;
    // Use this for initialization
    void Start()
    {
        Direction = player.transform.position - transform.position;
    }

    private bool See()
    {
        if (Vector3.Angle(Direction,transform.forward) <= 360*0.5f)
        {
            if (Physics.Raycast(transform.position,Direction, out hit,10))
            {
                return (hit.transform.CompareTag("Player"));
            }
        }
        return false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(transform.position, Direction, out hit))
        {
            if (hit.transform == player.transform)
            {
                //seen
                Debug.Log("Seen");
                ennemy.transform.LookAt(player.transform);
                ennemy.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            }
            else
            {
                Debug.Log("not");
                //not seen
            }
        }



    }
}
