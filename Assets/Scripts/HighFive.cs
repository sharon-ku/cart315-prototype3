using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFive : MonoBehaviour
{
    public GameObject hand;
    public GameObject cat;

    private float numSlaps = 0;
    private float totalSlapsForCat = 3;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == hand)
        {
            numSlaps++;

            // Play sound effect
            if (numSlaps == totalSlapsForCat)
            {
                cat.SetActive(true);

                Debug.Log("show cat");
            }

        }
    }
}
