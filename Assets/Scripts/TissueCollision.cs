using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueCollision : MonoBehaviour
{
    public GameObject hand;
    // Sound effect
    public AudioSource soundEffect;

    private bool stuckToHand = false;

    [Header("Position offset to hand")]
    // y (height) offset (moves it lower)
    public float handThickness = 2.5f;
    // z offset (moves it up the fingers)
    public float zOffsetToHand = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // If tissue is stuck to hand:
        if (stuckToHand)
        {
            // Assign tissue to hand position, with some offset
            transform.position = hand.transform.position + new Vector3(0, -handThickness, zOffsetToHand);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == hand)
        {
            Debug.Log("grabbed the lovely tissue");

            if (!stuckToHand)
            { 
                // Play sound effect
                soundEffect.Play();

                // Tissue gets stuck to hand
                stuckToHand = true;

                // Ignore collision between hand and tissue
                Physics.IgnoreCollision(hand.GetComponent<Collider>(), GetComponent<Collider>());
            } 

            
        }
    }
}
