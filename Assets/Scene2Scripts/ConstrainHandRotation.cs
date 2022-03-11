using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainHandRotation : MonoBehaviour
{
    [Header("Limit Rot")]
    public float minZRot = -3f;
    public float maxZRot = 7f;

    public float minYRot = -3f;
    public float maxYRot = 7f;


    // Private vars
    private Vector3 mousePos;
    private Transform localTrans;


    // Start is called before the first frame update
    void Start()
    {
        localTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0, 0, 0f);
    }

    public void LimitRot()
    {
        Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;

        playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, minZRot, maxZRot);

        localTrans.rotation = Quaternion.Euler(playerEulerAngles);
    }
}
