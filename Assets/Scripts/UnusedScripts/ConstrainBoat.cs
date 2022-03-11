using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainBoat : MonoBehaviour
{
    public float xPositionConstrain = 5f;

    public bool boatCapsized = false;

    [Header("Limit Rot")]
    public float maxZRot = 20f;
    public float minZRot = 20f;

    // Private vars
    private Vector3 mousePos;
    private Transform localTrans;

    // Start is called before the first frame update
    void Start()
    {
        localTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {   
        /*
        // Constrain x position 
         transform.position = new Vector3(Mathf.Clamp(transform.position.x, xPositionConstrain, xPositionConstrain), transform.position.y, transform.position.z);
        if (transform.position.x > xPositionConstrain)
        { 
            transform.position = new Vector3(xPositionConstrain, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xPositionConstrain)
        { 
            transform.position = new Vector3(-xPositionConstrain, transform.position.y, transform.position.z);
        }
        */

        // If boat falls behind the camera, set boatCapsized to true
        if (transform.position.z < Camera.main.transform.position.z)
        {
            boatCapsized = true;
        }

        // LimitRot();
    }

    public void LimitRot()
    {
        Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;

        playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, minZRot, maxZRot);

        localTrans.rotation = Quaternion.Euler(playerEulerAngles);
    }
}
