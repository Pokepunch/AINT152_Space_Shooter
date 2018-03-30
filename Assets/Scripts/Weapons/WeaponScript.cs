using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public float fireTime = 0.5f;
    
    public GameObject bulletPrefab;
    public Transform[] bulletSpawn;
    private WeaponController shootBullet;

    private void OnEnable ()
    {
        WeaponController.OnWeaponFire += Fire;
        shootBullet = transform.parent.GetComponent<WeaponController>();
    }

    private void OnDisable()
    {
        WeaponController.OnWeaponFire -= Fire;
    }

    void Fire()
    {
        shootBullet.IsFiring = true;
        foreach (Transform spawn in bulletSpawn)
        {
            Instantiate(bulletPrefab, spawn.position, spawn.rotation);
        }
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        shootBullet.Invoke("SetFiring", fireTime);
    }
}
