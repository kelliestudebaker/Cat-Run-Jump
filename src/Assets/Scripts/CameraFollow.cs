using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool bounds;
    public Vector3 minValues;
    public Vector3 maxValues;

    [SerializeField]
    protected Transform cameraTarget;

    [SerializeField]
    float xOffset; //Offset the camera left or right.

    [SerializeField]
    float yOffset; //Offset the camera up or down.

    void Update()
    {
        //The camera's position is updated to match the target's (player's) position.
        transform.position = new Vector3(cameraTarget.position.x + xOffset, 
            cameraTarget.position.y + yOffset, transform.position.z);

        if (bounds)
        {
            //Set boundaries to keep the camera from going off the level.
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minValues.x, maxValues.x),
                Mathf.Clamp(transform.position.y, minValues.y, maxValues.y),
                Mathf.Clamp(transform.position.z, minValues.z, maxValues.z));
        }

    }
}
