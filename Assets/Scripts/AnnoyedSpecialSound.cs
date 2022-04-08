using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnoyedSpecialSound : MonoBehaviour
{
    public GameObject hand;
    // Sound effect
    public AudioSource soundEffect;
    public AudioSource specialSoundEffect;

    private float countTillSpecialSound = 2;
    private float numPresses = 0;

    // force for moving left, right, front, back
    public float movementSpeed = 50f;

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
            // Starting vector: no force applied to hand
            Vector3 vector = new Vector3(0, 0, 0);
            vector += new Vector3(movementSpeed, 0, 0);

            // Add 1 to press count
            numPresses++;

            // If number of special counts met:
            if (numPresses % countTillSpecialSound == 0)
            {
                // Play special sound effect
                specialSoundEffect.Play();
            }
            else 
            {
                // Play normal sound effect
                soundEffect.Play();
            }

            // Add vector to current vector
            this.GetComponent<Rigidbody>().velocity = vector;

        }
    }
}
