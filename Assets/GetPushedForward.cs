using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPushedForward : MonoBehaviour
{
    public bool boatReachedTheEnd = false;
    public float zFinalPosition = 830f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {   
        // Keep pushing boat or camera until final z position
        if (transform.position.z < zFinalPosition)
        { 
            this.GetComponent<Rigidbody>().AddForce(0, 0, 0.1f);
        }
        else
        {
            boatReachedTheEnd = true;
 
        }



    }
}
