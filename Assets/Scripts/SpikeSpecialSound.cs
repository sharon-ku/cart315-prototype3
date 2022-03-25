using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpecialSound : MonoBehaviour
{
    public GameObject hand;
    // Sound effect
    public AudioSource soundEffect;
    public AudioSource specialSoundEffect;

    private float countTillSpecialSound = 5;
    private float numPresses = 0;

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
            Debug.Log("SLAPPED");
            
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
            
        }
    }
}
