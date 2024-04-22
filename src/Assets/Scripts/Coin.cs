using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject coin;
    public static int score;
    public Text coinText;

    void Start()
    {
        score = 0;
        coinText.text = score.ToString();
    }

    private void changeScore()
    {
        score++;
        coinText.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            changeScore();
            Debug.Log("Score is now " + score);
            Destroy(gameObject); //Destroy the coin after it has been collected.
        }
    }
}
