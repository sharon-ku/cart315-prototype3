using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingHeadBlinks : MonoBehaviour
{
    //public GameObject cat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject findCat = GameObject.Find("Cat");
        CatBehaviour cs = findCat.GetComponent<CatBehaviour>();
        bool thisCatOnHead = cs.onTopOfHead;

        //bool catCs = cat.GetComponent<CatBehaviour>();
        //bool thisCatOnHead = catCs.onTopOfHead;

        if (thisCatOnHead)
        {
         
            // Rotate eyes so that they're open
            transform.rotation = Quaternion.Euler(0, 0, -175f);

            // Hide snore particles
            GameObject findSnoreParticles = GameObject.Find("SnoreParticles");
            findSnoreParticles.SetActive(false);

        }
    }
}
