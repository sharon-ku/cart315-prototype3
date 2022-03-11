using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapHand : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {   
        // Put hand at starting y position
        ResetYPosition();
    }

    // Put hand back to its original y position
    void ResetYPosition()
    {
        position = transform.position; // get the position
        position.y = initialYPosition; // assign initialYPosition to its y component
        transform.position = position; // assign the position back to the transform
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
        // Slap hand down
        HandleSlapping();

    }

   

    // Handle hand slapping down and going back up (with space bar or mouse click)
    void HandleSlapping()
    {
        // Press down: either with space bar or on mouse click
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Slap hand down
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, -slapForce, 0);
       
            // After delay of __ seconds, reset y position
            Invoke("ResetYPosition", 0.1f);
        }

        // If done slapping, then put hand back up
        // if (transform.position.y <= 0)
        // {
          
            // // Stop moving hand
            // // this.GetComponent<Rigidbody>().AddForce(0, 0, 0);
            // // this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            // // Put hand at starting y position, aka move it back up
            // ResetYPosition();
            
        // }
    }

}
