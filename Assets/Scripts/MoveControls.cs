using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControls : MonoBehaviour
{

    // force for moving left, right, front, back
    public float movementSpeed = 15f;

    public GameObject face;

    // Sound effect
    public AudioSource soundEffect;


    private bool handHitFace = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // No movement vector
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

        // Add vector to current vector
        this.GetComponent<Rigidbody>().velocity = vector;

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
