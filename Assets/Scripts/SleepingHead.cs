using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingHead : MonoBehaviour
{
    public GameObject tissue;

    // Sound effect
    public AudioSource soundEffect;

    private bool tissueHitFace = false;

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
        if (collision.collider.gameObject == tissue)
        {
            Debug.Log("tissue on face");

            if (!tissueHitFace)
            {
                // Play sound effect
                soundEffect.Play();

                // Tissue gets transferred to face
                tissueHitFace = true;

       

                // Ignore collision between hand and tissue
                // Physics.IgnoreCollision(hand.GetComponent<Collider>(), GetComponent<Collider>());
            }


        }
    }
}
