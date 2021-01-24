using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraM : MonoBehaviour {

    public Camera CPl;
    
  
    // Use this for initialization
    void Start()
    {
        CPl = GetComponentInChildren<Camera>();                          
    }
    
	// Update is called once per frame
	void Update () {
       
	}
}
