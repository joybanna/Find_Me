using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class fireControl : NetworkBehaviour {

    public GameObject ShellPrefab;
    public GameObject PosShell;
    public int shootForce;
    private bool isShoot; 
    public Animator anim;
    public AudioClip audioC;
    private AudioSource audioS;
    void Start () {
        isShoot = true;
        audioS = GetComponent<AudioSource>();       
    }
	void Update ()
    {
       if (moveChar.isHunter)
        {
            if (!isLocalPlayer)
            {
                return;
            }
            if (Input.GetKeyUp(KeyCode.Space)&&isShoot)
            {                
                CmdShoot();   
            }
        }
	}
    void CreateBullet()
    {
        audioS.PlayOneShot(audioC, 1.0F);
        shootAnim();
        isShoot = false;
        StartCoroutine(delayBullet());
        StartCoroutine(delayShoot());
    }
    [Command]
    void CmdShoot()
    {        
        CreateBullet();
        RpcCreateBullet();
    }
    [ClientRpc]
    void RpcCreateBullet()
    {
        if (!isServer)//not sever can do
        {
            CreateBullet();
        }       
    }
    void shootAnim()
    {
        anim.SetTrigger("isHit");
    }
    IEnumerator delayBullet()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject bullet = Instantiate(ShellPrefab, PosShell.transform.position, PosShell.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = PosShell.transform.forward * shootForce;
        Destroy(bullet, 3.0f);
    }
    IEnumerator delayShoot()
    {
        yield return new WaitForSeconds(2f);
        isShoot = true;
    }

}
