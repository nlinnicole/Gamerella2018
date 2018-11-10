using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalController : MonoBehaviour {
    public float pigJump = 5;
    public float bunnyJump = 15;
    public float mouseJump = 0;

    public float pigSpeed = 15;
    public float bunnySpeed = 20;
    public float mouseSpeed = 25;

    private float speed;
    private float jumpForce;
    private Vector3 jump;

    private bool isGounded = true;

    private int animalType = 0;
    private bool isChanged = false;
    private bool isMoving = true;

    private Vector3 lastpos;
    private Vector3 movementVector = new Vector3();

    private int points;


    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && isGounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGounded = false;
        } else
        {
            Move();
        }
        checkAnimalType();
	}

    private void OnCollisionStay()
    {
        isGounded = true;
    }

    void Move()
    {
        if (isMoving)
        {
            //rb.velocity = new Vector3(0, 0, speed);
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            switchAnimalType();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Floor")
        {
            isMoving = false;
            if (!isChanged)
            {
                switchAnimalType();
                checkAnimalType();
            }
            reset();
        }

        if (col.gameObject.tag == "Rock")
        {
            
        }

        if (col.gameObject.tag == "Bush")
        {
            if (this.tag == "Piggy" || this.tag == "Bunny")
            {
                Destroy(col.gameObject);
                Debug.Log("ate bush");
            }
        }

        if (col.gameObject.tag == "Log")
        {
            if (this.tag == "Rat")
            {
                Destroy(col.gameObject);
                Debug.Log("under log");
            }
        }

        if (col.gameObject.tag == "Carrot")
        {
            if(this.tag == "Piggy" || this.tag == "Bunny")
            {
                Destroy(col.gameObject);
                points += 1; 
                Debug.Log("ate carrot");
            }
        }

        if (col.gameObject.tag == "Cheese")
        {
            if(this.tag == "Piggy" || this.tag == "Mouse")
            {
                Destroy(col.gameObject);
                points += 2;
                Debug.Log("ate cheese");
            }
        }

        if (col.gameObject.tag == "Garbage")
        {
            Destroy(col.gameObject);
            points--;
            Debug.Log("ate garbage");
        }
    }

    void switchAnimalType()
    {
        isChanged = true;
        if (animalType == 0)
        {
            animalType = 1;
            this.tag = "Bunny";
            Debug.Log("changed to bunny");
        }
        else if (animalType == 1)
        {
            animalType = 2;
            this.tag = "Mouse";
            Debug.Log("changed to mouse");
        }
        else if (animalType == 2)
        {
            animalType = 0;
            this.tag = "Piggy";
            Debug.Log("changed to piggy");
        }
        checkAnimalType();
    }

    void checkAnimalType()
    {
        if (animalType == 0)
        {
            jumpForce = pigJump;
            speed = pigSpeed;
        }
        else if (animalType == 1)
        {
            jumpForce = bunnyJump;
            speed = bunnySpeed;
        }
        else
        {
            jumpForce = mouseJump;
            speed = mouseSpeed;
        }
    }

    void reset()
    {
        transform.position = new Vector3(0, 0, 0);
        isMoving = true;

    }
}
