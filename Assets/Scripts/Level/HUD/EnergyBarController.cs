using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnergyBarController : MonoBehaviour
{
    public Image energyFill;

    private GameObject weaponController;

    private int index;

    void Start()
    {
        WeaponController.PlayerEnergyChanged += OnEnergyChanged;
    }

    private void OnDisable()
    {
        WeaponController.PlayerEnergyChanged -= OnEnergyChanged;
    }

    public void OnEnergyChanged(float energy, int i)
    {
        energyFill.fillAmount = energy / 10;
    }

    public void SetEnergy(float e)
    {
        OnEnergyChanged(e, index);
    }
}
