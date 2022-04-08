using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotPushButton : MonoBehaviour
{
    public GameObject hand;
    public GameObject butt;


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
            // Show butt
            butt.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
