using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullableCrate : MonoBehaviour {

    float delay = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
        
        if (delay > 0) return;


        if (Input.GetKey(KeyCode.K))
        {
            delay = 1;
            
            GameObject g = GameObject.FindGameObjectWithTag("Player");
            g.GetComponent<Animator>().SetTrigger("pull");
            if (Vector3.Distance(g.transform.position, transform.position) < 2f)
            {
                GetComponent<Rigidbody2D>().AddForce((g.transform.position - transform.position).normalized * 1000f);
            }

        }
    }

    
}
