using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "Piggy")
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        } else
        {
            //rock breaking animation
            transform.position = new Vector3 (transform.position.x, transform.position.y + 10, transform.position.z);
        }
    }
}
