using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainHandRotation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Set rotation to specific values
        // When using RigidBody, there's this issue where the hand wants to do crazy rotations
        // This function thus prevents it from doing unwanted acrobatics
        if (transform.rotation != Quaternion.Euler(new Vector3(-90, 180, 0)))
        {
            transform.rotation = Quaternion.Euler(new Vector3(-90, 180, 0));
        }
    }

}
