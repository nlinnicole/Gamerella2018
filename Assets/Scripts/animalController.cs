﻿using System.Collections;
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

    private bool isGrounded = true;

    private int animalType;
    private bool isChanged = false;
    private bool isMoving = true;
    private bool isJumping = false;

    private Vector3 lastpos;

    private GameObject piggy;
    private GameObject bunny;
    private GameObject mouse;

    private float originalHeight;

    private int points;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);

        piggy = this.gameObject.transform.GetChild(0).gameObject;
        bunny = this.gameObject.transform.GetChild(1).gameObject;
        mouse = this.gameObject.transform.GetChild(2).gameObject;

        animalType = animalSelect.animalSelection;
        switchAnimalType(animalType);

        originalHeight = transform.position.y;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            isJumping = true;
        } else 
        {
            Move();
        }
        checkAnimalType();
        if (transform.position.y > originalHeight)
        {
            Debug.Log("is jumping");
            isJumping = true;
        } else
        {
            isJumping = false;
        }
	}

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Move()
    {
        isGrounded = false;
        if (isMoving)
        {
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
            Debug.Log("hit floor");
            isMoving = false;
            if (!isChanged)
            {
                isChanged = true;
                switchAnimalType();
                checkAnimalType();
            }
            reset();
        }

        if (col.gameObject.tag == "Rock")
        {
            reset();
        }

        if (col.gameObject.tag == "Mushroom")
        {
            if (this.tag == "Piggy" || this.tag == "Bunny")
            {
                Destroy(col.gameObject);
                Debug.Log("ate mushroom");
            } else
            {
                reset();
            }
        }

        if (col.gameObject.tag == "Log")
        {
            if (this.tag == "Mouse")
            {
                Destroy(col.gameObject);
                Debug.Log("under log");
            }
            else
            {
                reset();
            }
        }

        if (col.gameObject.tag == "Carrot")
        {
            if(this.tag == "Piggy" || this.tag == "Bunny")
            {
                Destroy(col.gameObject);
                points += 1; 
                Debug.Log("ate carrot");
                Debug.Log(points);
            }
        }

        if (col.gameObject.tag == "Cheese")
        {
            if(this.tag == "Piggy" || this.tag == "Mouse")
            {
                Destroy(col.gameObject);
                points += 2;
                Debug.Log("ate cheese");
                Debug.Log(points);
            }
        }

        if (col.gameObject.tag == "Garbage")
        {
            Destroy(col.gameObject);
            points--;
            Debug.Log("ate garbage");
            Debug.Log(points);
        }
    }

    void switchAnimalType(int type)
    {
        if (type == 0)
        {
            toPiggy();
        }
        else if (type == 1)
        {
            toBunny();
        }
        else if (type == 2)
        {
            toMouse();
        }
        checkAnimalType();
    }

    void switchAnimalType()
    {
        if (animalType == 0)
        {
            toBunny();
        } else if (animalType == 1)
        {
            toMouse();
        }
        else
        {
            toPiggy();
        }
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
        Debug.Log("reset");
        this.transform.position = new Vector3(1, 1, 147);
        isMoving = true;
        isChanged = false;
    }

    public void toPiggy()
    {
        animalType = 0;
        this.tag = "Piggy";
        piggy.SetActive(true);
        bunny.SetActive(false);
        mouse.SetActive(false);
        originalHeight = this.transform.position.y;
        Debug.Log(animalType);
        Debug.Log("changed to piggy");
    }

   public void toMouse()
    {
        animalType = 2;
        this.tag = "Mouse";
        mouse.SetActive(true);
        bunny.SetActive(false);
        piggy.SetActive(false);
        originalHeight = this.transform.position.y;
        Debug.Log(animalType);
        Debug.Log("changed to mouse");
    }

    public void toBunny()
    {
        animalType = 1;
        this.tag = "Bunny";
        bunny.SetActive(true);
        piggy.SetActive(false);
        mouse.SetActive(false);
        originalHeight = this.transform.position.y;
        Debug.Log(animalType);
        Debug.Log("changed to bunny");
    }
}
