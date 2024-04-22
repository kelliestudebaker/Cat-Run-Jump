using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 0.5f; //How long before the platform falls.
    private float destroyDelay = 2f; //How long before the platform is destroyed.

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Start the "Fall" coroutine if the player jumps on the platform.
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay); //Wait for (fallDelay) seconds before executing.
        rb.bodyType = RigidbodyType2D.Dynamic; //Change the platform Body Type from Kinematic to Dynamic, causing it to fall.
        Destroy(gameObject, destroyDelay); //Destroy the platfrom after (destroyDelay) seconds have passed.
    }
}
