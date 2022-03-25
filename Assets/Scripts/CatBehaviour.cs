using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    public GameObject hand;
    // State of cat being on top of the hand
    private bool onTopOfHand = false;
    // Number of times hand hit cat
    private float numHits = 0;

    // Sound effect
    public AudioSource soundEffect;

    [Header("Position offset to hand")]
    // y (height) offset (moves it lower)
    public float handThickness = 2.5f;
    // z offset (moves it up the fingers)
    public float zOffsetToHand = 2f;

    // Start is called before the first frame update
    void Start()
    {   
        // Hide cat to begin with
        // High five hand will reactivate the cat
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If cat on top of hand:
        if (onTopOfHand && numHits >=1)
        {
            // Assign cat to hand position, with some offset
            transform.position = hand.transform.position + new Vector3(0, handThickness, zOffsetToHand);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == hand)
        {
            // Prepare cat to be on top of hand
            if (!onTopOfHand && numHits == 0)
            {
                // Play sound effect
                soundEffect.Play();

                // The next time we hit cat, cat will be on top of hand
                numHits++;

                // Cat will be on top of hand on next collision
                onTopOfHand = true;

                // Ignore collision between hand and hand
                Physics.IgnoreCollision(hand.GetComponent<Collider>(), GetComponent<Collider>());
            }


        }
    }
}
