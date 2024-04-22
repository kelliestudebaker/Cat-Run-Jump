using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject gameObjectToDestroy;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "CatStomp") //"CatStomp" is a Box Collider 2D attached to the cat's paws.
        {
            Destroy(gameObjectToDestroy); //Destroy the enemy when it is jumped on.
            Debug.Log("Destroyed enemy");
        }
    }
}
