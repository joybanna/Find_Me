using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class setuplocalNor : NetworkBehaviour {
    [SyncVar(hook = "OnChangeChar")] public int numCh = 0;
    [SyncVar(hook = "OnHitBullet")] public int numHit = 0;
    private float timeInGame;
    private int timeIngameI;
    private Camera CPl;  
    void Start()
    {
        CPl = GetComponentInChildren<Camera>();
        timeInGame = 180;
        if (isLocalPlayer)
        {           
            GetComponent<moveChar>().enabled = true;
            CPl.enabled = true;
        }
        else
        {          
            GetComponent<moveChar>().enabled = false;
            CPl.enabled = false;
        }
    }		
	void Update ()
    {
        CheckTime();
        CheckTypeUser();
        CheckHitHideLose();
        CheckTimeOut(); 
    }

    private void CheckTime()
    {
        float timePro = timeInGame -= Time.deltaTime;
        timeIngameI = (int)Mathf.Round(timePro);
        DDOL.ttime = timeIngameI;
    }
    private void CheckTypeUser()
    {
        if (isLocalPlayer)
        {
            numCh = uim.num;
        }

        if (numCh == 1)
        {
            moveChar.isHunter = false;
        }
        else
        {
            moveChar.isHunter = true;
        }
    }
    private void CheckHitHideLose()
    {
        if (numHit > 0)
        {
            WinLose.isPanal = true;
            Time.timeScale = 0.0f;
            if (isLocalPlayer)
            {

                WinLose.isLose = true;
            }
            else
            {
                WinLose.isLose = false;
            }
        }
    }
    private void CheckTimeOut()
    {
        if (timeIngameI <= 0)
        {
            WinLose.isPanal = true;
            Time.timeScale = 0.0f;
            if (isLocalPlayer)
            {
                if (moveChar.isHunter)
                {
                    WinLose.isLose = true;
                }
                else
                {
                    WinLose.isLose = false;
                }
            }
            else
            {
                if (moveChar.isHunter)
                {
                    WinLose.isLose = false;
                }
                else
                {
                    WinLose.isLose = true;
                }
            }
        }
    }
    private void OnChangeChar(int ch)
    {
        numCh = ch;
    }
    private void OnHitBullet(int h)
    {
        numHit = h;
    }
    [Command]
    private void CmdOnChangeChar(int num)
    {
        numCh = num;
    }
    [Command]
    private void CmdOnHitBullet(int h)
    {
        numHit = h;      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isLocalPlayer && collision.gameObject.tag == "bullet")
        {
            CmdOnHitBullet(1);
        }
    }
}
