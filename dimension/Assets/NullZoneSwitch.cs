using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullZoneSwitch : MonoBehaviour {

    public GameObject[] targets;
    
	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
    }
    float delay = 0;
    void OnTriggerStay2D(Collider2D other)
    {

        if (delay > 0) return;

        if (other.gameObject.name == "Player")
        {
            if (other.GetComponent<PlayerRewind>() != null && other.GetComponent<PlayerRewind>().isTriggerDelayed()) return;
            if (Input.GetKey(KeyCode.Space))
            {
                delay = 1;
                //FF00007B
                for (int i = 0; i < targets.Length; i++)
                {
                    if (!targets[i].GetComponent<NullZone>().enabled)
                    {
                        targets[i].GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 123f / 255f);
                        targets[i].GetComponent<NullZone>().enabled = true;
                    }
                    else
                    {
                        targets[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                        targets[i].GetComponent<NullZone>().enabled = false;
                    }
                }
            }
        }
    }


}
