using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy1 : MonoBehaviour
{
    private Transform target;

    private bool canMove = true;

    public GameObject bullet;
    public Transform[] spawns;

    public float speed = 3.0f;
    public bool isFiring = false;
    public float fireDelay = 3;
    public float fireDistance = 1;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (GetComponent<BasicEnemyBehaviour>().onScreen)
        {
            if (transform.position.x - target.position.x >= 0)
            {
                if (target != null && canMove)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y), speed * Time.deltaTime);
                }
                float distanceY = transform.position.y - target.position.y;
                if (distanceY > fireDistance || distanceY > -fireDistance)
                {
                    if (!isFiring)
                    {
                        canMove = false;
                        isFiring = true;
                        Invoke("SetCanMove", 1);
                        Invoke("Shoot", 0.5f);
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x - 10, transform.position.y), (speed * 3) * Time.deltaTime);
            }
        }
    }

    void SetNotFiring()
    {
        isFiring = false;
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
        Invoke("SetNotFiring", fireDelay);
    }
}
