using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SkillHide : NetworkBehaviour
{
    [SyncVar(hook = "OnHideDD")] public int numHide = 0;
    public Transform target;
    private Rigidbody rb;
    public GameObject Hideskin;
    private BoxCollider Bcol;
    public float timehide = 7.0f;
    public float rang = 1.0f;
    private bool ishideAgain;
    void Start()
    {
        ishideAgain = true;
        rb = this.GetComponent<Rigidbody>();      
        Bcol = this.GetComponent<BoxCollider>();
    }
    void Update()
    {
        if (!moveChar.isHide && !moveChar.isHunter)
        {
            if (target != null)
            {
                if (Input.GetKeyUp(KeyCode.F) && numHide != 1)
                {
                    numHide = 1;
                }
            }    
        }
        checkOB();
        if (isLocalPlayer)
        {
            CmdOnHideDD(numHide);
            OnHideDD(numHide);
        }
        else
        {
            CmdOnHideDD(0);
            OnHideDD(0);
        }
        
    }
    private void hideskill()
    {
        if (target != null&&ishideAgain)
        {
           if(isLocalPlayer)
            {
                moveChar.isHide = true;
            }
            ishideAgain = true;
            Hideskin.SetActive(false);           
            Bcol.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            StartCoroutine(hidtime(timehide));
        }
    }
    void show()
    {
        Hideskin.SetActive(true);
        Bcol.enabled = true;
        moveChar.isHide = false;
        StartCoroutine(hidDelay(5));
        CmdOnHideDD(0);
    }
    void checkOB()
    {
        Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.forward) * rang, Color.blue);
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, rang))
        {
            if (hit.transform.tag == "OB")
            {
                target = hit.transform;
                print("Ray ready!!");
            }
        }
        else
        {
            target = null;
        }

    }
    IEnumerator hidtime(float time)
    {
        yield return new WaitForSeconds(time);
        show();
    }
    IEnumerator hidDelay(float time)
    {
        yield return new WaitForSeconds(time);
        ishideAgain = true;
    }
    private void OnHideDD(int h)
    {
        numHide = h;
      
        if (numHide == 1)
        {
            hideskill();
        }
    }
    [Command]
    private void CmdOnHideDD(int h)
    {
        numHide = h;
        if (numHide == 1)
        {
            hideskill();
        }
    }




}
