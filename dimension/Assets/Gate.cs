using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    public bool horizontal = false;
    Vector3 oldScale = -Vector3.one;
    public bool startOpen = false;
    bool open;
	void Start () {
        oldScale = transform.localScale;
        if (startOpen) transform.localScale = Vector3.zero;
        open = startOpen;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Press()
    {
        
        if (!open)
        {
            
            transform.DOKill();
            oldScale = transform.localScale;
            
            if (horizontal) transform.DOScaleX(0, 1.1f);
            else transform.DOScaleY(0, 1.1f);
        }
        else
        {
              
            transform.DOKill();
            transform.DOScale(oldScale, 0.25f);
        }
        open = !open;
            
    }
}
