using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSound : MonoBehaviour
{
    public GameObject hand;
    // Sound effect
    public AudioSource soundEffect;

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

            // Play sound effect
            soundEffect.Play();
        }
    }
}
