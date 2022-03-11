using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoat : MonoBehaviour
{
    public float rotationSpeed = 0.3f;
    public float sidePushingForce = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Transform>().Rotate(0, 0, rotationSpeed);
            this.GetComponent<Rigidbody>().AddForce(sidePushingForce, 0, 0);
        }

        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Transform>().Rotate(0, 0, -rotationSpeed);
            this.GetComponent<Rigidbody>().AddForce(-sidePushingForce, 0, 0);
        }

        else
        {
            this.GetComponent<Rigidbody>().AddForce(0, 0, 0);
        }

    }

}
