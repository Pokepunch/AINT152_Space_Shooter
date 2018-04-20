using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    // Create a delegate and an event for the player firing. 
    public delegate void WeaponFire();
    public static event WeaponFire OnWeaponFire;

    /// <summary>
    /// Array containing each weapon GameObject.
    /// </summary>
    public GameObject[] weaponList;
    /// <summary>
    /// Array used for checking if a weapon has been unlocked or not.
    /// </summary>
    public bool[] isWeaponUnlocked;
    /// <summary>
    /// Index of currently equipped weapon.
    /// </summary>
    public int weaponIndex;
    /// <summary>
    /// Set when the player is firing.
    /// </summary>
    public bool isFiring = false;

    private void Start()
    {
        weaponIndex = 0; // Get the index of the starter weapon.
        weaponList[weaponIndex].SetActive(true);
        Cursor.visible = false;
    }

    void Update()
    {
        if (!StaticVariables.gamePaused)
        {
            if (Input.GetButtonDown("WeaponChangeUp"))
            {
                DisableWeapon(weaponIndex);
                weaponIndex++;
                if (weaponIndex > weaponList.Length - 1)
                {
                    weaponIndex = 0;
                }
                EnableWeapon(weaponIndex);
                Debug.Log("Weapon changed - increase. Weapon index is " + weaponIndex, gameObject);
            }
            else if (Input.GetButtonDown("WeaponChangeDown"))
            {
                DisableWeapon(weaponIndex);
                if (weaponIndex == 0)
                {
                    weaponIndex = weaponList.Length - 1;
                }
                else
                {
                    weaponIndex--;
                }
                EnableWeapon(weaponIndex);
                Debug.Log("Weapon changed - decrease. Weapon index is " + weaponIndex, gameObject);
            }
            if (Input.GetMouseButton(0))
            {
                if (!isFiring)
                {
                    if (OnWeaponFire != null)
                    {
                        IsFiring = true;
                        OnWeaponFire();
                        Invoke("SetNotFiring", weaponList[weaponIndex].GetComponent<WeaponScript>().fireTime);
                    }
                }
            }
        }
    }

    void RestoreEnergy(float amount)
    {
        float currEnergy = weaponList[weaponIndex].GetComponent<WeaponScript>().energy;
        currEnergy += amount;
        if (currEnergy > 10)
        {
            currEnergy = 10;
        }
        weaponList[weaponIndex].GetComponent<WeaponScript>().energy = currEnergy;
    }

    void SetNotFiring()
    {
        isFiring = false;
    }

    public void EnableWeapon(int index)
    {
        weaponList[index].SetActive(true);
    }

    public void DisableWeapon(int index)
    {
        weaponList[index].SetActive(false);
    }

    public bool IsFiring
    {
        get
        {
            return isFiring;
        }
        set
        {
            isFiring = value;
        }
    }
}
