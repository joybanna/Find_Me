using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SyncVar(hook = "OnChangeAnimation")] public float animState = 0.0f;
    [SyncVar(hook = "OnChangeChar")] public int numCh = 0;

    public GameObject[] charOB;
    public Animator animH, animJ;

    // Use this for initialization
    void Start()
    {
        
        charOB[0].SetActive(false);
        charOB[1].SetActive(false);

        if (isLocalPlayer)
        {
            //SmoothFollowCamera.target = this.gameObject.transform;
           // SmoothFollowCamera.targetRigidbody = this.GetComponent<Rigidbody>();
            GetComponent<CharMovement>().enabled = true;

        }
        else
        {
            GetComponent<CharMovement>().enabled = false;
        }
    }
    void OnGUI()
    {
        if (isLocalPlayer)
        {
            CmdOnChangeChar(numCh);
        }
    }

    // Update is called once per frame
    void Update()
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
    void OnChangeAnimation(float s)
    {
        if (isLocalPlayer)
        {
            return;
        }
        else
        {
            UpdateAnimationState(s);
        }
    }
    [Command]
    public void CmdOnChangeChar(int num)
    {
        numCh = num;
    }
   
    [Command]
    public void CmdChangeAnimationState(float s)
    {
        UpdateAnimationState(s);
    }

    void UpdateAnimationState(float s)
    {      
        animH.SetFloat("moveSpeed", s);
        animJ.SetFloat("moveSpeed", s);
    }
}
