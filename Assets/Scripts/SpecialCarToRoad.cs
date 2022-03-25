using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCarToRoad : MonoBehaviour
{
    public GameObject road;
    public GameObject hand;

    // Distance between car and road
    float distance;

    // Distance required for car to attach to road
    float distanceToAttach = 4f;

    private bool driving = false;

    public float drivingSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // Calculate the distance between road and special car
        distance = Vector3.Distance(road.transform.position, transform.position);

        // If special car is close enough to road
        //if (distance < distanceToAttach)
        //{
        // Put car on road
        //transform.position = new Vector3(6.53f, -26.93161f, 27.84081f);
        //}

        Debug.Log(transform.position);

        // Set rotation to specific values
        // When using RigidBody, there's this issue where the hand wants to do crazy rotations
        // This function thus prevents it from doing unwanted acrobatics
        if (transform.rotation != Quaternion.Euler(new Vector3(-90, 0, 0)))
        {
            transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
        }

        // Have car start driving
        if (driving)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, drivingSpeed);

            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == hand)
        {
            Debug.Log("hand hit special car");


            // Put car on road
            // transform.position = new Vector3(6.53f, -26.93161f, 27.84081f);
            transform.position = new Vector3(14.11f, -2.78f, 205.684f);

            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

            transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));

            driving = true;

            Debug.Log(transform.position);

        }
    }
}
