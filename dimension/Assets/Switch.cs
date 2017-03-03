using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Switch : MonoBehaviour {

    public GameObject[] targetGates;
    public bool requiresKeyPress = false;
    public bool horizontal = false;
    public bool isButton = false;
    Vector3 initialScale;
    bool pressed = false;
    float delay = 0;
    int side = 0;
    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
         
        
	}
    int onbutton = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (requiresKeyPress) return;

        if (other.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            if (!isButton)
            {
                if (other.GetComponent<PlayerRewind>() != null && other.GetComponent<PlayerRewind>().isTriggerDelayed()) return;

                if (horizontal) side = transform.position.y.CompareTo(other.transform.position.y);
                else side = transform.position.x.CompareTo(other.transform.position.x);
            }
            else
            {
                if (onbutton == 0)
                {
                    foreach (GameObject go in targetGates)
                        go.GetComponent<Gate>().Press();
                }
                onbutton++;
                Debug.Log(onbutton);
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (requiresKeyPress) return;
        

        if (other.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            if (!isButton)
            {
                if (other.GetComponent<PlayerRewind>() != null && other.GetComponent<PlayerRewind>().isTriggerDelayed()) return;
                int s = 0;
                if (horizontal) s = transform.position.y.CompareTo(other.transform.position.y);
                else s = transform.position.x.CompareTo(other.transform.position.x);
                
                if (s == -side)
                {
                    foreach (GameObject go in targetGates)
                        go.GetComponent<Gate>().Press();
                }
            }
            else
            {
                onbutton--;
                Debug.Log(onbutton);
                if (onbutton == 0)
                {
                    foreach (GameObject go in targetGates)
                        go.GetComponent<Gate>().Press();
                }
            }
        }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (!requiresKeyPress) return;
        if (delay > 0) return;

        if (other.gameObject.name == "Player")
        {
            if (other.GetComponent<PlayerRewind>() != null && other.GetComponent<PlayerRewind>().isTriggerDelayed()) return;
            if (Input.GetKey(KeyCode.Space))
            {
                delay = 1;
                foreach (GameObject go in targetGates)
                    go.GetComponent<Gate>().Press();
            }
        }
    }

   
}
