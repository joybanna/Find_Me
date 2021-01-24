using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, 7);
    }
}
