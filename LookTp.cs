using UnityEngine;
using System.Collections;

public class LookTp : MonoBehaviour {

    public float TpCool = 10;
    public float Timer;
    private RaycastHit Last;
    public AudioClip SoundTp;
	// Use this for initialization
	void Start () {
	
	}
    private GameObject Looking()
    {

        Vector3 origin = transform.position;
        Vector3 direction = Camera.main.transform.forward;
        float range = 1000;
        if (Physics.Raycast(origin, direction, out Last, range))
            return Last.collider.gameObject;
        else
            return null;
    }

    private void TpToLook()
    {
        transform.position = Last.point + Last.normal*2;
        if (SoundTp != null)
            AudioSource.PlayClipAtPoint(SoundTp, transform.position);

    }
	
	// Update is called once per frame
	void Update () {
        if (Timer < 0)
            Timer = 0;
        if (Timer > 0)
            Timer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && Timer == 0)
            if (Looking() != null)
            {
                Timer = TpCool;
                TpToLook();
            }
	}
	void OnGUI(){
		GUI.Box (new Rect (Screen.width - 170, Screen.height - 30, 170, 25), "Tp cooldown time : " + ((int)Timer).ToString ());
	}
}
