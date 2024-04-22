using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public GameObject life;
    public static int numLives = 3; //Number of lives the player has.
    public Text lifeText;

    void Start()
    {
        lifeText.text = numLives.ToString(); //Represent the number of lives as text on the canvas.
    }

    private void addLife()
    {
        numLives++;
        lifeText.text = numLives.ToString();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player")) //If the player touches a life object...
        {
            addLife(); //Add one to the total lives.
            Debug.Log("Lives are now " + numLives);
            Destroy(gameObject); //Destroy the life game object.
        }
    }
}
