using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianShootScript : MonoBehaviour
{
    // Used to determine if the boss is active.
    private bool isRunning = false;

    // Is the boss firing
    private bool isFiring = false;

    // The prefab for the bullet, and its spawn point
    public GameObject bullet;
    public Transform bulletSpawn;

    public float fireDistance = 2;

    // The player.
    private Transform player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Hero").transform;
        BossIntroScript.IntroEnd += Begin;
	}


    // Get the boss going.
    public void Begin()
    {
        SetCantFire(1);
        isRunning = true;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (isRunning)
        {
            float distanceY = transform.position.y - player.position.y;
            if (distanceY < fireDistance && distanceY > -fireDistance  && !isFiring)
            {
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                SetCantFire(1.5f);
            }
        }
	}

    public void SetCantFire(float time)
    {
        isFiring = true;
        Invoke("SetNotFiring", time);
    }

    void SetNotFiring()
    {
        isFiring = false;
    }
}
