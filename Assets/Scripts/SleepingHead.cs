using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingHead : MonoBehaviour
{
    public GameObject hand;

    // Sound effect
    public AudioSource soundEffect;
    public AudioSource sneezeSoundEffect;

    // Store whether cat is on head (need to fetch info from CatBehaviour script)
    private bool thisCatOnHead = false;

    // Number of times head sneezed
    private float numSneezes = 0;

    // Sound effect
    public AudioSource snoreSound;

    public bool handHitFace = false;

    // Start is called before the first frame update
    void Start()
    {
        // Play snore sound
        
        snoreSound.Play();
            // snoreSound.PlayOneShot(snoreSound.clip);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject go = GameObject.Find("Cat");
        CatBehaviour catBehaviour = go.GetComponent<CatBehaviour>();
        CatBehaviour cs = catBehaviour;
        thisCatOnHead = cs.onTopOfHead;

        if (thisCatOnHead && numSneezes < 1)
        {
            //// Stop snoring
            //snoreSound.Stop();
            //snoreSound.loop = false;

            // Play sneezing
            sneezeSoundEffect.Play();

            Debug.Log("cat on head");
            
            // Increase 1 sneeze
            numSneezes++;
            
            
        }


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
