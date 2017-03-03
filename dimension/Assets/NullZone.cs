using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullZone : MonoBehaviour {
    public bool startsOn = true;
	// Use this for initialization
	void Start () {
        if (!startsOn) GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        else GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 123f/255f);

        enabled = startsOn;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerStay2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.name == "Player")
        {
            other.GetComponent<PlayerRewind>().breakRewind();
        }
    }
}
