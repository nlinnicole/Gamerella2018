using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraConroller : MonoBehaviour {

    public GameObject player;
    float offset;

    // Use this for initialization
    void Start () {
        offset = transform.position.z - player.transform.position.z;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offset);
	}
}
