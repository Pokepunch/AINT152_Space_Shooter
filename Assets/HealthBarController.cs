using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] healthObjects;
    [SerializeField]
    private int playerHealth = 10;

	// Use this for initialization
	void Start ()
    {
        DamageBehaviourPlayer.PlayerOnDamage += OnPlayerDamaged;
        DamageBehaviourPlayer.PlayerOnHeal += OnPlayerHeal;
	}

    public void OnPlayerDamaged(int health)
    {
        for (int i = playerHealth; i > health; i--)
        {
            healthObjects[i-1].SetActive(false);
        }
        playerHealth = health;
    }

    public void OnPlayerHeal(int health)
    {
        for (int i = playerHealth; i < health; i++)
        {
            healthObjects[i].SetActive(true);
        }
        playerHealth = health;
    }
}
