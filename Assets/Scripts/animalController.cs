using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalController : MonoBehaviour {
    public float speed;
    public float jump;

    private int animalType = 0;
    private bool isMoving = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        checkAnimalType();
	}

    void Move()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jump;
        }
    }


    void checkAnimalType()
    {
        if (animalType == 0)
        {
            jump = 5;
            speed = 10;
        }
        else if (animalType == 1)
        {
            jump = 15;
            speed = 17;
        }
        else
        {
            jump = 0;
            speed = 25;
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Floor")
        {
            isMoving = false;
            if (animalType == 0)
            {
                animalType = 1;
                Debug.Log("changed to bunny");
            }
            else if (animalType == 1){
                animalType = 2;
                Debug.Log("changed to mouse");
            }
            else if (animalType == 2)
            {
                animalType = 0;
                Debug.Log("changed to piggy");
            }
            checkAnimalType();
        }
    }
}
