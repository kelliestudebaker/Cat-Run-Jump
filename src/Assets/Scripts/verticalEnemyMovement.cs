using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalEnemyMovement : MonoBehaviour
{
    //This script was used in the test scene.
    
    [SerializeField]
    float speed = 2f; //How quickly the spike moves up and down.

    [SerializeField]
    float height = 0.5f; //How high the spike goes.

    Vector3 pos;

    private void Start()
    {
        pos = transform.position; //Make sure the spike stays in its position on start.
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
