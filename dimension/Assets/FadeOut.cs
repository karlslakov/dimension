using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().DOColor(new Color(0, 0, 0, 0), 3f).SetDelay(8f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
