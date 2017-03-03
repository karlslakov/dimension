using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveGround : MonoBehaviour {
    public float dX = 0;
    public float dY = 0;
    public float delay = 0;
    //Vector3 initialPos;
    public float duration = 1;
    //float t = 0;
    //float d = 1;
    Tweener myTween = null;

	// Use this for initialization
	void Start () {
        myTween = transform.DOMove(transform.position + new Vector3(dX, dY), duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuint).SetDelay(delay);
        //initialPos = transform.position;

    }
	void forward()
    {
        
    }

    void backward()
    {
        //myTween = (transform.position - new Vector3(dX, dY), duration).OnComplete(forward);
    }
    // Update is called once per frame
    
    void Update () {
        //if (d > 0 )
        //{
        //    t += Time.deltaTime;
        //    if (t > duration)
        //    {
        //        t = duration;
        //        d = -1;
        //    }
        //}
        //else
        //{
        //    t -= Time.deltaTime;
        //    if (t < 0)
        //    {
        //        t = 0;
        //        d = 1;
        //    }
        //}
	}

    void FixedUpdate()
    {
        //if (GetComponent<Rigidbody2D>() == null) return;
        //Debug.Log(initialPos);
        //GetComponent<Rigidbody2D>().MovePosition(initialPos + new Vector3(dX, dY) * (t / duration));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player") other.transform.parent = transform;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player") other.transform.parent = null;
    }
}
