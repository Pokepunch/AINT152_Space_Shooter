using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public Image healthFill;

	void Start ()
    {
        DamageBehaviorPlayer.PlayerOnHealthChanged += OnHealthChanged;
	}

    private void OnDisable()
    {
        DamageBehaviorPlayer.PlayerOnHealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged(int health)
    {
        healthFill.fillAmount = (float)health / 10;
    }
}
