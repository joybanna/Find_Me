using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharMovement : MonoBehaviour
{
    static public bool isHunter;
    public bool isHide;
    private Transform target;
    public float speed;
    public float speedrotate = 50.0f;
    public Animator animH,animJ;
    private Rigidbody rb;
    public GameObject bodyH;
    public float timehide = 3.0f;
    public Transform pointshow;
    public float long_rang = 1.0f;
    
    

    // Use this for initialization
    void Start ()
    {   
        rb = GetComponent<Rigidbody>();
        isHide = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isHunter)
        {
            movement();
            Attack();
        }
        else if (!isHunter)
        {
            if (!isHide)
            {
                hideskill();
                movement();
                checkOB();
            }

        }

    }
    void movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speedrotate;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        this.transform.Translate(0, 0, moveVertical * Time.deltaTime);
        this.transform.Rotate(0, moveHorizontal * Time.deltaTime, 0);

       
        anitmationController(moveVertical);

    }
    void Attack()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animJ.SetTrigger("isHit");
        }
    }
    void hideskill()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (rb)
            {
                if (target != null)
                {
                    isHide = true;
                    bodyH.SetActive(false);
                    transform.position = target.transform.position;
                    Destroy(rb);
                    StartCoroutine(hidtime(timehide));
                    animH.SetFloat("moveSpeed", 0);
                }
               
            }
        }

    }
    void show()
    {
        if (!rb)
        {
            bodyH.SetActive(true);
            
            transform.position = pointshow.transform.position;

            this.gameObject.AddComponent<Rigidbody>();
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ|RigidbodyConstraints.FreezePositionY;
            isHide = false;
        }

    }
    void checkOB()
    {
        Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.forward) * long_rang, Color.blue);
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, long_rang))
        {
            target = hit.transform;
            //print(hit);
        }
        else
        {
            target = null; 

        }
    }
    void anitmationController(float m)
    {
        this.GetComponent<SetupLocalPlayer>().CmdChangeAnimationState(m);

        animH.SetFloat("moveSpeed", m);
        animJ.SetFloat("moveSpeed", m);
    }
    IEnumerator hidtime(float time)
    {
        yield return new WaitForSeconds(time);
        show();
    }
}
