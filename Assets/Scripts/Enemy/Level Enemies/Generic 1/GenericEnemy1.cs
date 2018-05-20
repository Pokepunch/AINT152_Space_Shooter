using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy1 : MonoBehaviour
{
    private Transform target;

    private bool canMove = true;

    public GameObject bullet;
    public Transform[] spawns;

    public float ySpeed = 3.0f;
    public bool hasFired = false;
    public float fireDelay = 3;
    public float fireDistance = 1;

    private int frameCounter = 0;
    public int direction;

    private bool doubleSpeedDone = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (GetComponent<BasicEnemyBehavior>().onScreen)
        {
            if (!doubleSpeedDone)
            {
                DoubleSpeed();
                doubleSpeedDone = !doubleSpeedDone;
            }
            if (transform.position.x - target.position.x >= 0 && !hasFired)
            {
                if (target != null && canMove)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y), ySpeed * Time.deltaTime);
                }
                float distanceY = transform.position.y - target.position.y;
                frameCounter--;
                if (frameCounter <= 0)
                {
                    if (distanceY < 0)
                    {
                        direction = -1;
                    }
                    else
                    {
                        direction = 1;
                    }
                    frameCounter = 30;
                }
                if (distanceY < fireDistance && distanceY > -fireDistance)
                {
                    canMove = false;
                    hasFired = true;
                    direction *= -1;
                    Invoke("SetCanMove", 1);
                    Invoke("Shoot", 0.5f);
                }
            }
            else if (canMove)
            {
                if (!hasFired)
                {
                    direction = 0;
                }
                transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x - 10, transform.position.y - (10 * direction)), ySpeed * Time.deltaTime);
            }
        }
    }

    private void DoubleSpeed()
    {
        GetComponent<ScrollingScript>().multiplier = 10;
    }

    void SetCanMove()
    {
        canMove = true;
    }

    void Shoot()
    {
        foreach (Transform spawn in spawns)
        {
            Instantiate(bullet, spawn.position, spawn.rotation);
        }
    }
}
