using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyBossFirebreather : MonoBehaviour
{
    public GameObject gameObjectToDestroy;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "CatStomp")
        {
            Destroy(gameObjectToDestroy); //Destroy the enemy when it is jumped on.
            Debug.Log("Destroyed enemy");
            SceneManager.LoadScene("13Level5Complete"); //Load the "Level 5 Complete" scene once the boss is defeated.
            CatController.health = 3;
        }
    }
}
