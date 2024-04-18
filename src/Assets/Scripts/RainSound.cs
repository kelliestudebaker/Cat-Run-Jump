using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSound : MonoBehaviour
{
    public AudioSource rainSource;

    void Start()
    {
        rainSource.Play(); //Play the rain sound when the scene starts.
    }
}
