using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawnRight;
    public Transform bulletSpawnLeft;
    public float fireTime = 0.5f;
    private bool isFiring = false;

    void SetFiring()
    {
        isFiring = false;
    }

    void Fire()
    {
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawnRight.position, bulletSpawnRight.rotation);
        Instantiate(bulletPrefab, bulletSpawnLeft.position, bulletSpawnLeft.rotation);
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}
