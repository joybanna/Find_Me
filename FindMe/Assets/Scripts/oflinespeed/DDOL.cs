using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DDOL : MonoBehaviour {

    Text textT;
    static public int ttime;

    void Start()
    {
        textT = GetComponent<Text>();
    }
    void Update()
    {
        textT.text = ttime.ToString();
    }
   
	
}
