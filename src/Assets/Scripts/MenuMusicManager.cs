using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicManager : MonoBehaviour
{
    //This script keeps the music from starting over whenever the menu scene is loaded.
    //It also ensures the music stops once the scene is exited (excluding the level select scene).

    private static MenuMusicManager instance;

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
        if (scene.buildIndex == 2) //Stop the menu music from playing if a level is selected...
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        else if (scene.buildIndex == 3)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        else if (scene.buildIndex == 4)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        else if (scene.buildIndex == 5)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        else if (scene.buildIndex == 6)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
