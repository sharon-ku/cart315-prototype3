using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHand : MonoBehaviour
{
    public float smoothness;
    public Transform targetObject;
    private Vector3 initialOffset;
    private Vector3 affectedOffset;
    private Vector3 cameraPosition;
    private Vector3 initialYPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialOffset = transform.position - targetObject.position;
        initialYPosition = new Vector3(0,transform.position.y,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        affectedOffset = new Vector3(initialOffset.x, 0, initialOffset.z);
        cameraPosition = targetObject.position + affectedOffset + initialYPosition;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);
    }
}
