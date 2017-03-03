using DG.Tweening;
using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public GameObject frame;
    public GameObject fade;
    public GameObject text1;
    public GameObject text2;
    public GameObject rain;
    public GameObject endScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("sad");
        if (other.name == "Player")
        {
            Destroy(GameObject.Find("Timer"));
            StartCoroutine("end");
            
        }
    }

    IEnumerator end()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Camera>().enabled = false;
        frame.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        fade.GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 5.6f);
        text1.GetComponent<Text>().DOColor(new Color(0, 0, 0, 1), 8f).SetDelay(1f);
        text2.GetComponent<Text>().DOColor(new Color(0, 0, 0, 1), 3f).SetDelay(7f);
        rain.GetComponent<RainScript2D>().EnableWind = false;
        rain.GetComponent<RainScript2D>().RainIntensity = 0;
        yield return new WaitForSeconds(2.3f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRewind>().enabled = false;

        yield return new WaitForSeconds(9f);
        endScreen.GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 4f);
        fade.GetComponent<Image>().DOColor(new Color(0, 0, 0, 1), 4f);
        text1.GetComponent<Text>().DOColor(new Color(0, 0, 0, 1), 1);
        text2.GetComponent<Text>().DOColor(new Color(0, 0, 0, 1), 1);



    }
}
