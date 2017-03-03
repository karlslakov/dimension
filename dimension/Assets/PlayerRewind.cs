using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine.UI;
using DigitalRuby.RainMaker;

public class PlayerRewind : MonoBehaviour {

    LinkedList<Vector3> myBoyz = new LinkedList<Vector3>();
    LinkedList<Vector3> velOcityBoyz = new LinkedList<Vector3>();
    //TweenerCore<Vector3, Path, PathOptions> theTweenz;
    Tweener theTweenz;
    public AudioClip heartbeat;
    public GameObject rain;
    Vector3[] path;
    

    public GameObject flash;
    public RectTransform bar;
    float delay = 0;
    float triggerDelay = 0;

    float timePOWER = 130f;
    bool r = false;

	// Use this for initialization
	void Start () {
        myBoyz.AddLast(transform.position);
        velOcityBoyz.AddLast(GetComponent<Rigidbody2D>().velocity);
        
    }
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
        triggerDelay -= Time.deltaTime;
        bar.localScale = new Vector3(timePOWER / 130f, bar.localScale.y, bar.localScale.y);
        timePOWER += Time.deltaTime * 15;
        if (timePOWER > 130) timePOWER = 130;
    }

    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.J) && timePOWER > 0 && myBoyz.Count > 3)
        {
            if (theTweenz == null)
            {
                if (delay < 0)
                {
                    //path = new Vector3[myBoyz.Count];
                    //int i = 0;

                    //for (LinkedListNode<Vector3> curr = myBoyz.Last; curr != null; curr = curr.Previous)
                    //{
                    //    path[i] = curr.Value;
                    //    i++;

                    //}
                    //GameObject.Find("LineRenderer").GetComponent<LineRenderer>().numPositions = (path.Length);
                    //GameObject.Find("LineRenderer").GetComponent<LineRenderer>().SetPositions(path);

                    //float duration = path.Length / 5f;
                    r = true;
                    //theTweenz = transform.DOPath(path, duration, PathType.CatmullRom).OnComplete(stop).SetEase(Ease.OutFlash).SetDelay(0.75f);
                    theTweenz = transform.DOMove(myBoyz.Last.Value, 0.1f).OnComplete(doNext).SetDelay(0.75f).SetEase(Ease.InOutSine);
                    GetComponent<Rigidbody2D>().gravityScale = 0;
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    GetComponent<Collider2D>().isTrigger = true;

                    if (flash != null && flash.GetComponent<Image>() != null)
                    {
                        flash.GetComponent<Image>().DOColor(new Color(0.9f, 0.9f, 0.9f, 0.3f), 1).SetEase(Ease.OutBounce).easeOvershootOrAmplitude = 2;
                        GetComponent<AudioSource>().PlayOneShot(heartbeat, 8f);
                    }
                    
                    //rain.GetComponent<RainScript2D>()
                    
                }
            }
            else
                timePOWER -= Time.deltaTime * 25;
        }





        if (theTweenz != null)
        {
            if (!Input.GetKey(KeyCode.J))
                stop();

        }
        else
        {
            if (Vector3.Distance(transform.position, myBoyz.Last.Value) > 0.5f)
            {
                myBoyz.AddLast(transform.position);
                velOcityBoyz.AddLast(GetComponent<Rigidbody2D>().velocity);
                if (myBoyz.Count > 200) { myBoyz.RemoveFirst(); velOcityBoyz.RemoveFirst(); }
            }
        }



    }

    void doNext()
    {
        if (myBoyz.Count == 0) stop();
        theTweenz = transform.DOMove(myBoyz.Last.Value, 0.1f).OnComplete(doNext).SetEase(Ease.InOutSine) ;
        myBoyz.RemoveLast();
        velOcityBoyz.RemoveLast();

    }
    void stop()
    {
        //if (myBoyz.Count > 0)
        //{
        //    Vector3 targetpos = transform.position;
        //    Vector3 closest = myBoyz.Last.Value;
        //    float distance = Vector3.Distance(closest, targetpos);
        //    foreach (Vector3 v in myBoyz)
        //    {
        //        float d = Vector3.Distance(v, targetpos);
        //        if (d < distance)
        //        {
        //            closest = v;
        //            distance = d;
        //        }
        //    }
        //   // Debug.Log(myBoyz.Count);
        //    while (myBoyz.Last.Value != closest)
        //    {
        //        myBoyz.RemoveLast();
        //        velOcityBoyz.RemoveLast();
        //    }
        //    //Debug.Log(myBoyz.Count);
        //}

        theTweenz.Kill(); theTweenz = null;

        r = false;
        
        GetComponent<Collider2D>().isTrigger = false;
        Vector3 q = Vector3.zero;
        if (velOcityBoyz.Count > 0)
        {
            q = velOcityBoyz.Last.Value;
        }
        GetComponent<Rigidbody2D>().velocity = q;
        GetComponent<Rigidbody2D>().gravityScale = 2;
        myBoyz.AddLast(transform.position);
        velOcityBoyz.AddLast(q);
        
        delay = 1.5f;
        triggerDelay = 0.1f;

        resetFlash();
    }

    public void breakRewind()
    {
        if (theTweenz != null)
        {
            stop();
            
        }
    }
    public bool isR() { return theTweenz != null; }
    public bool isTriggerDelayed()
    {
        return theTweenz != null || triggerDelay > 0;
    }

    void resetFlash()
    {
        if (flash == null || flash.GetComponent<Image>() == null) return;
        flash.GetComponent<Image>().DOKill();
        flash.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
    }
}
