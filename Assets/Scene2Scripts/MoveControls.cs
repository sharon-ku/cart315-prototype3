using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControls : MonoBehaviour
{

    // force for moving left, right, front, back
    public float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Take care of movement (with arrow keys or WASD)
        // Move right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // this.GetComponent<Transform>().Rotate(0, 0, rotationSpeed);
            this.GetComponent<Rigidbody>().velocity = new Vector3(movementSpeed, 0, 0);
        }

        // Move left
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // this.GetComponent<Transform>().Rotate(0, 0, -rotationSpeed);
            this.GetComponent<Rigidbody>().velocity = new Vector3(-movementSpeed, 0, 0);
        }

        // Move front
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            // this.GetComponent<Transform>().Rotate(0, 0, rotationSpeed);
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, movementSpeed);
        }

        // Move back
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            // this.GetComponent<Transform>().Rotate(0, 0, rotationSpeed);
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -movementSpeed);
        }

        // No movement
        else
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
