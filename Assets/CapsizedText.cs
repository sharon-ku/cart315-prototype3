using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsizedText : MonoBehaviour
{
    public Text myText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        

        if (GameObject.Find("Boat").GetComponent<GetPushedForward>().boatReachedTheEnd == true)
        {
            myText.text = "The End";
        }
        else
        {
            if (GameObject.Find("Boat").GetComponent<ConstrainBoat>().boatCapsized == true)
            {
                myText.text = "Capsized";
            }
        }
    }
}
