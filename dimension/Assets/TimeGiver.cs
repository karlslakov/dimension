using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGiver : MonoBehaviour {

    public float time = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    bool triggered = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.name == "Player")
        {
            GameObject.FindGameObjectWithTag("Respawn").GetComponent<TimerScript>().t += time;
            triggered = true;   
        }
    }
}
