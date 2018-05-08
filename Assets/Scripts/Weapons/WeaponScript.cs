using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    /// <summary>
    /// Determines the delay between firing.
    /// </summary>
    public float fireTime = 0.5f;
    /// <summary>
    /// The energy of the weapon.
    /// </summary>
    public float energy = 10.0f;
    /// <summary>
    /// The ammount of energy it costs to fire the weapon.
    /// </summary>
    public float energyCost = 1.0f;
    /// <summary>
    /// Set for weapons that use a seperate script for weapon logic.
    /// </summary>
    public bool isSpecialWeapon = false;

    public GameObject bulletPrefab;
    public Transform[] bulletSpawn;

    private void OnEnable ()
    {
        if (!isSpecialWeapon)
        {
            WeaponController.OnWeaponFire += Fire;
        }
    }

    private void OnDisable()
    {
        if (!isSpecialWeapon)
        {
            WeaponController.OnWeaponFire -= Fire;
        }
    }

    void Fire()
    {
        if (energy != 0)
        {
            foreach (Transform spawn in bulletSpawn)
            {
                Instantiate(bulletPrefab, spawn.position, spawn.rotation);
            }
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            EnergySubtract();
        }
    }

    public void EnergySubtract()
    {
        if (energy < energyCost)
        {
            energy = 0;
        }
        else if (energyCost > 0)
        {
            energy -= energyCost;
        }
        Debug.Log(gameObject.name + ": energy is " + energy);
    }
}
