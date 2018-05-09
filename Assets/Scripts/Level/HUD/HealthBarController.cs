using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField]
    private Image healthFill;

	void Start ()
    {
        DamageBehaviorPlayer.PlayerOnHealthChanged += OnPlayerChanged;
	}

    private void OnDisable()
    {
        DamageBehaviorPlayer.PlayerOnHealthChanged -= OnPlayerChanged;
    }

    public void OnPlayerChanged(int health)
    {
        healthFill.fillAmount = (float)health / 10;
    }
}
