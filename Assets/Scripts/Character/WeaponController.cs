using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    // Create a delegate and an event for the player firing. 
    public delegate void WeaponFire();
    public static event WeaponFire OnWeaponFire;

    public delegate void PlayerOnEnergyChanged(float energy, int index);
    public static event PlayerOnEnergyChanged PlayerEnergyChanged;

    public delegate void WeaponSwitch(bool changeUp, int index, int numbWeaps);
    public static event WeaponSwitch OnWeaponSwitch;

    // Array containing each weapon GameObject.
    public GameObject[] weaponList;

    // Array used for checking if a weapon has been unlocked or not.
    public bool[] isWeaponUnlocked;

    // Index of currently equipped weapon.
    public int weaponIndex;

    // Set when the player is firing.
    public bool isFiring = false;

    // Set if the player can switch weapons.
    public bool canSwitch = true;

    // The delay in seconds of switching weapons.
    public float switchDelay = 0.3f;

    private void Start()
    {
        weaponIndex = 0; // Get the index of the starter weapon.
        weaponList[weaponIndex].SetActive(true);
        Cursor.visible = false;
    }

    void Update()
    {
        if (!StaticVariables.gamePaused && !StaticVariables.controlLock)
        {
            if (canSwitch)
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
                    if (OnWeaponSwitch != null)
                    {
                        OnWeaponSwitch(true, weaponIndex, weaponList.Length - 1);
                    }
                    canSwitch = false;
                    Invoke("SetCanSwitch", switchDelay);
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
                    if (OnWeaponSwitch != null)
                    {
                        OnWeaponSwitch(false, weaponIndex, weaponList.Length - 1);
                    }
                    canSwitch = false;
                    Invoke("SetCanSwitch", switchDelay);
                    Debug.Log("Weapon changed - decrease. Weapon index is " + weaponIndex, gameObject);
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (!isFiring)
                {
                    if (OnWeaponFire != null)
                    {
                        isFiring = true;
                        OnWeaponFire();
                        Invoke("SetNotFiring", weaponList[weaponIndex].GetComponent<WeaponScript>().fireTime);
                        SubtractEnergy();
                    }
                }
            }
        }
    }

    public void SubtractEnergy()
    {
        float currEnergy = weaponList[weaponIndex].GetComponent<WeaponScript>().energy;
        float cost = weaponList[weaponIndex].GetComponent<WeaponScript>().energyCost;
        if (currEnergy < cost)
        {
            currEnergy = 0;
        }
        else if (cost > 0)
        {
            currEnergy -= cost;
        }
        weaponList[weaponIndex].GetComponent<WeaponScript>().energy = currEnergy;
        if (PlayerEnergyChanged != null)
        {
            PlayerEnergyChanged(currEnergy, weaponIndex);
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
        if (PlayerEnergyChanged != null)
        {
            PlayerEnergyChanged(currEnergy, weaponIndex);
        }
    }

    void SetNotFiring()
    {
        isFiring = false;
    }

    void SetCanSwitch()
    {
        canSwitch = true;
    }

    public void EnableWeapon(int index)
    {
        weaponList[index].SetActive(true);
    }

    public void DisableWeapon(int index)
    {
        weaponList[index].SetActive(false);
    }
}
