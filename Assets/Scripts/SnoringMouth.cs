using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnoringMouth : MonoBehaviour
{
 
    public float minWidth = 0.56f;
    public float maxWidth = 1;
    public float growthSpeed = 0.005f;
    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(-growthSpeed, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale += scaleChange;

        // Grow mouth if it's small
        if (transform.localScale.x <= minWidth || transform.localScale.x >= maxWidth)
        {
            scaleChange = -scaleChange;
     
        }
    }
}
