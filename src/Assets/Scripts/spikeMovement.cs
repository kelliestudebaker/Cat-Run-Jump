using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 2f; //How quickly the enemy moves up and down.

    [SerializeField]
    float height = 0.5f; //How high the enemy goes.

    Vector3 pos;

    private void Start()
    {
        pos = transform.position; //Make sure the enemy stays in its position on start.
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
