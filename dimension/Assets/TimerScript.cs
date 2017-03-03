using DG.Tweening;
using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public GameObject text;
    public Image fade;
    public AudioClip voice;
    public AudioClip car;


    public float t = 1f * 60f;
	void Start () {
        GameObject.Find("Image (1)").GetComponent<Image>().rectTransform.localScale = new Vector3(Screen.width * 0.2f, Screen.height * 0.3f, 0);
	}

    // Update is called once per frame
    bool ended = false;
	void Update () {
        t -= Time.deltaTime;
        if (t < 0)
        {
            t = 0;
            if (!ended)
            {
                fade.DOColor(Color.black, 8.5f);
                Camera.main.DOOrthoSize(1, 1);
                GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(voice);
                
                ended = true;
                StartCoroutine("bus");
            }

            
        }
        int s = (int)(t % 60);
        int m = Mathf.FloorToInt(t / 60f);
        text.GetComponent<Text>().text = m.ToString() + ":" + (s < 10 ? "0" : "") + s;
        
	}

    IEnumerator bus()
    {

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        p.GetComponent<PlayerMovement>().enabled = false;

        Destroy(GameObject.FindGameObjectWithTag("kill"), 2.03f);
        GameObject.Find("MayuriCam").GetComponent<Camera>().rect = new Rect(0, 0.65f, 0.35f, 0.35f);
        Destroy(GameObject.Find("Image (1)"));
        
        GameObject go = GameObject.FindGameObjectWithTag("Finish");
        go.transform.DOMove(go.transform.position - new Vector3(15, 0), 3.5f).SetEase(Ease.OutQuint).SetDelay(1.7f) ;
        yield return new WaitForSeconds(0.36f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(car, 0.4f);
        yield return new WaitForSeconds(2f);
        p.GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(6);
        SceneManager.UnloadSceneAsync("test");
        SceneManager.LoadScene("test");
        
    }

    
}
