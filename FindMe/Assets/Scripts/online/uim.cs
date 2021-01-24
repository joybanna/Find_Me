using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class uim : MonoBehaviour {

    static public int num;
   
	// Use this for initialization
	void Start () {

        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void one()
    {
        num = 1;
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void two()
    {
        num = 2;
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
