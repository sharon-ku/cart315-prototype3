using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingHead : MonoBehaviour
{
    public GameObject hand;

    // Sound effect
    public AudioSource soundEffect;

    // Sound effect
    public AudioSource snoreSound;

    public bool handHitFace = false;

    // Start is called before the first frame update
    void Start()
    {
        // Play nore esound
        snoreSound.Play();
        // snoreSound.PlayOneShot(snoreSound.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == hand)
        {
            Debug.Log("hand on face");

            // Play sound effect
            soundEffect.Play();

            if (!handHitFace)
            {
                // Tissue gets transferred to face
                handHitFace = true;

                // After delay of __ seconds, reset y position
                Invoke("handNotHitFace", 0.1f);

                // Ignore collision between hand and tissue
                // Physics.IgnoreCollision(hand.GetComponent<Collider>(), GetComponent<Collider>());
            }


        }
    }

    // Reset hand hitting face to false
    private void HandNotHitFace()
    {
        handHitFace = false;
    }

}
