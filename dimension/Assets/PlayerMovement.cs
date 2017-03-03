using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    float speed = 5;
    float accel = 1;

	// Use this for initialization
	void Start () {
        Physics2D.queriesStartInColliders = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKey(KeyCode.W);
    }
    bool jump = false;
    float horizontal = 0;


    void FixedUpdate()
    {
        bool isOnGround = false;
        if (GetComponent<PlayerRewind>().isR()) return;
        
        RaycastHit2D[] hit1 = Physics2D.RaycastAll(transform.position - new Vector3(0.005f, 0, 0), Vector2.down, GetComponent<Collider2D>().bounds.extents.y + 0.1f);
        RaycastHit2D[] hit2 = Physics2D.RaycastAll(transform.position + new Vector3(0.005f, 0, 0), Vector2.down, GetComponent<Collider2D>().bounds.extents.y + 0.1f);
        foreach (RaycastHit2D h in hit1)
        {
            if (h.collider != null && !h.collider.isTrigger)
            {
                isOnGround = true;
                break;
            }
        }
        if (!isOnGround)
        {
            foreach (RaycastHit2D h in hit2)
            {
                if (h.collider != null && !h.collider.isTrigger)
                {
                    isOnGround = true;
                    break;
                }
            }
        }
        

        
        
        

        Vector3 velocity = GetComponent<Rigidbody2D>().velocity;

        if (horizontal > 0)

        {
            velocity = Vector3.MoveTowards(velocity, new Vector3(speed, velocity.y), accel);
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("running", true);
        }
        else if (horizontal < 0)
        {
            velocity = Vector3.MoveTowards(velocity, new Vector3(-speed, velocity.y), accel);
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("running", true);
        }
        else
        {
            velocity = new Vector3(0, velocity.y);
            GetComponent<Animator>().SetBool("running", false);
        }

        GetComponent<Animator>().SetBool("jumping", !isOnGround);

        if (jump && isOnGround)
        {
           // Debug.Log("jump");
            velocity.y = 6f;
        }

        GetComponent<Rigidbody2D>().velocity = velocity;

        


    }
}
