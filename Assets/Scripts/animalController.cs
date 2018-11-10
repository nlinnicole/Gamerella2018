using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalController : MonoBehaviour {

    public float speed;
    public float jump;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }
    
		
	}
}
