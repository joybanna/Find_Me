using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour {

    public GameObject Pw;
    public GameObject Pl;
    static public bool isLose;
    static public bool isWin;
    static public bool isPanal;

    // Use this for initialization
    void Start ()
    {
        isPanal = false;
        if (!isPanal)
        {
            Pl.SetActive(false);
            Pw.SetActive(false);
        }
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isPanal)
        {
            if (isLose)//lose
            {
                Pl.SetActive(true);
                Pw.SetActive(false);
            }
            else//win
            {
                Pl.SetActive(false);
                Pw.SetActive(true);
            }
        }    		
	}
}
