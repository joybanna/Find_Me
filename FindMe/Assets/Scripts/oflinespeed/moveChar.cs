using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveChar : MonoBehaviour {

    private float speed;
    public float speedrotate = 50.0f;
    static public bool isHunter;
    static public bool isHide;
    public GameObject Model;
    Animator anim;
    // Use this for initialization
    void Start ()
    {
        anim = Model.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        print(speed);
        if (isHunter)
        {
            speed = 3.5f;
            movement();            
        }
        else if (!isHunter&& !isHide)
        {
            speed = 3.5f;
            movement();     
        }
    }
    private  void movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speedrotate;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        this.transform.Translate(0, 0, moveVertical * Time.deltaTime);
        this.transform.Rotate(0, moveHorizontal * Time.deltaTime, 0);

        AnimMove(moveVertical);
    }

    private void AnimMove(float m)
    {
        anim.SetFloat("moveSpeed", m);
    }
}
