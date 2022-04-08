using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    public GameObject hand;
    public GameObject sleepingHead;
    private float closeDistanceToHead = 10f;

    // State of cat being on top of the hand
    private bool onTopOfHand = false;
    // Number of times hand hit cat
    private float numHits = 0;

    // Sound effect
    public AudioSource soundEffect;

    [Header("Position offset to hand")]
    // y (height) offset (moves it lower)
    public float handThickness = 2.5f;
    // z offset to hand (moves it up the fingers)
    public float zOffsetToHand = 2f;
    // y offset to head (moves it lower)
    public float headThickness = 2.2f;

    // Start is called before the first frame update
    void Start()
    {   
        // Hide cat to begin with
        // High five hand will reactivate the cat
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If cat on top of hand:
        if (onTopOfHand && numHits >=1)
        {
            // Assign cat to hand position, with some offset
            transform.position = hand.transform.position + new Vector3(0, handThickness, zOffsetToHand);

            CatCloseToHead();

            CatTransferToHead();
           
        }

       
       
    }

    // Move cat to top of head
    public void CatTransferToHead()
    {
        

        //if (sleepingHead.handHitFace)
        //{
        //    Debug.Log("cat on face now");

        //    // Assign cat to hand position, with some offset
        //    transform.position = sleepingHead.transform.position + new Vector3(0, handThickness, zOffsetToHand);
        //}
    }

    private void CatCloseToHead()
    {
        // Calculate the distance between road and special car
        float distanceToHead = Vector3.Distance(sleepingHead.transform.position, transform.position);

        // If cat is close to the head, keep meowing
        if (distanceToHead < closeDistanceToHead)
        {   
            // Move cat to top of face
            transform.position = sleepingHead.transform.position + new Vector3(0, headThickness, zOffsetToHand);

            // Play sound effect
            soundEffect.Play();

            // Make cat meow a LOT
            //soundEffect.loop = true;
            //soundEffect.Play();

            Debug.Log("close to head");

        }
        else
        {
            // Stop playing sound effect
            //soundEffect.Stop();
            //soundEffect.loop = false;
            Debug.Log("no head");
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
