using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraConroller : MonoBehaviour {

    public GameObject player;
    float offsetz;
    float offsetx;

    // Use this for initialization
    void Start () {
        offsetz = transform.position.z - player.transform.position.z;
        offsetx = transform.position.x - player.transform.position.x;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(player.transform.position.x + offsetx, transform.position.y, player.transform.position.z + offsetz);
	}
}
