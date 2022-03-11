using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    public float rotationSpeed = 0.3f;
    public float sidePushingForce = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Move right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Transform>().Rotate(0, 0, rotationSpeed);
            this.GetComponent<Rigidbody>().AddForce(sidePushingForce, 0, 0);
        }

        // Move left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Transform>().Rotate(0, 0, -rotationSpeed);
            this.GetComponent<Rigidbody>().AddForce(-sidePushingForce, 0, 0);
        }

        // Move front
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            // this.GetComponent<Transform>().Rotate(0, 0, rotationSpeed);
            this.GetComponent<Rigidbody>().AddForce(0, 0, sidePushingForce);
        }

        // Move back
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            // this.GetComponent<Transform>().Rotate(0, 0, rotationSpeed);
            // this.GetComponent<Rigidbody>().AddForce(0, 0, -sidePushingForce);

            // this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

    }

}
