using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class testselect : NetworkBehaviour {

    [SyncVar(hook = "OnChangeChar")] public int numCh=0;
    public GameObject[] charOB;    
    // Use this for initialization
    void Start ()
    {
       
        charOB[0].SetActive(false);
        charOB[1].SetActive(false);
    }
    // Update is called once per frame
    void OnGUI()
    {
        if (isLocalPlayer)
        {
            CmdOnChangeChar(numCh);
        }
        
    }
    void Update ()
    {
        if (isLocalPlayer)
        {
            numCh = uim.num;          
        }

        if (numCh == 1)
        {
            CharMovement.isHunter = false;
            charOB[0].SetActive(true);
            charOB[1].SetActive(false);
        }
        else
        {
            CharMovement.isHunter = true;
            charOB[0].SetActive(false);
            charOB[1].SetActive(true);
        }
    }  
    void OnChangeChar(int ch)
    {
        numCh = ch;    
    }
    [Command] public void CmdOnChangeChar(int num)
    {
        numCh = num;
    }
    
    

}
