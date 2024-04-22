using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaunch : MonoBehaviour
{
    public GameObject firePrefab;
    public Transform launchPoint;

    public float shootTime;
    public float shootCounter;

    Animator anim;

    void Start()
    {
        shootCounter = shootTime;

        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (shootCounter <= 0)
        {
            Instantiate(firePrefab, launchPoint.position, Quaternion.identity); //Spawn a fireball at the launchPoint's position.
            anim.SetBool("isShooting", true);
            shootCounter = shootTime;
        }
        else if(shootCounter <= 0.9)
        {
            anim.SetBool("isShooting", false);
        }

        shootCounter -= Time.deltaTime;
    }
}
