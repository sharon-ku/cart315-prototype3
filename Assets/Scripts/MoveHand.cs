using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    [Header("Forces")]
    // rotation speed: UNUSED
    public float rotationSpeed = 0.3f;
    // force for moving left, right, front, back
    public float sidePushingForce = 10f;
    // force of splappage downward
    public float slapForce = 35f;

    [Header("Y position")]
    Vector3 position;

    // initial y position of hand
    public float initialYPosition = 3.39f;


    // force for moving left, right, front, back
    public float movementSpeed = 15f;

    public GameObject face;

    private bool handHitFace = false;

    private bool slapping = false;

    // Sound effect
    public AudioSource soundEffect;




    // Start is called before the first frame update
    void Start()
    {
        // Put hand at starting y position
        ResetYPosition();
    }

    // Put hand back to its original y position
    void ResetYPosition()
    {
        slapping = false;

        position = transform.position; // get the position
        position.y = initialYPosition; // assign initialYPosition to its y component
        transform.position = position; // assign the position back to the transform
    }


    // Update is called once per frame
    void FixedUpdate()
    {   
        // If not slapping down, move hand like normal
        if (!slapping)
            {
                NormalMovement();
            }
    }

    private void NormalMovement()
    {
        // Set rotation to specific values
        // When using RigidBody, there's this issue where the hand wants to do crazy rotations
        // This function thus prevents it from doing unwanted acrobatics
        if (transform.rotation != Quaternion.Euler(new Vector3(-90, 180, 0)))
        {
            transform.rotation = Quaternion.Euler(new Vector3(-90, 180, 0));
        }


        // Starting vector: no force applied to hand
        Vector3 vector = new Vector3(0, 0, 0);

        // Take care of movement (with arrow keys or WASD)
        // Move right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // this.GetComponent<Transform>().Rotate(0, 0, rotationSpeed);
            vector += new Vector3(movementSpeed, 0, 0);
        }

        // Move left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // this.GetComponent<Transform>().Rotate(0, 0, -rotationSpeed);
            vector += new Vector3(-movementSpeed, 0, 0);
        }

        // Move front
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            // this.GetComponent<Transform>().Rotate(0, 0, rotationSpeed);
            vector += new Vector3(0, 0, movementSpeed);
        }

        // Move back
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            // this.GetComponent<Transform>().Rotate(0, 0, rotationSpeed);
            vector += new Vector3(0, 0, -movementSpeed);
        }

        // No movement
        // if (!Input.anyKey)
        // {
        // this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        // }

        // Add vector to current vector
        this.GetComponent<Rigidbody>().velocity = vector;
    }

    private void Update()
    {
        // Slap hand down
        HandleSlapping();

    }


    // Handle hand slapping down and going back up (with space bar or mouse click)
    void HandleSlapping()
    {
        // Press down: either with space bar or on mouse click
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            slapping = true;

            Debug.Log("slapping");

            // Slap hand down
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, -35f, 0);

            // After delay of __ seconds, reset y position
            Invoke("ResetYPosition", 0.1f);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == face)
        {
            Debug.Log("hand on face");

            if (!handHitFace)
            {
                // Play sound effect
                soundEffect.Play();

                // Tissue gets transferred to face
                handHitFace = true;



                // Ignore collision between hand and tissue
                // Physics.IgnoreCollision(hand.GetComponent<Collider>(), GetComponent<Collider>());
            }


        }
    }
}


