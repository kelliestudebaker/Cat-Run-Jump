using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L5MusicManager : MonoBehaviour
{
    //This script keeps the music from starting over when the player dies in a level.
    //It also ensures the music stops once the level is exited.

    private static L5MusicManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 12) //Stop the Level 5 music from playing if the Level 5 Complete scene is loaded.
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        else if (scene.buildIndex == 0) //Stop the Level 5 music from playing if the Title Screen scene is loaded.
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        else if (scene.buildIndex == 7) //Stop the Level 5 music from playing if the Game Over scene is loaded.
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
