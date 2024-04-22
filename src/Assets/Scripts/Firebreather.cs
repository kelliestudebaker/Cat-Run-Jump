using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject fireball;

    public Rigidbody2D fireRB;
    public float speed;

    public float fireLife; //How long the fireball lasts.
    public float fireCount; //Countdown before the fireball disappears.

    void Start ()
    {
        fireCount = fireLife;
    }

    void Update()
    {
        fireCount -= Time.deltaTime;
        if(fireCount <= 0 )
        {
            Destroy(gameObject); //Destroy the fireball once the countdown reaches 0.
        }
    }

    private void FixedUpdate()
    {
        fireRB.velocity = new Vector2(speed, fireRB.velocity.y); //Speed of the fireball.
    }
}
