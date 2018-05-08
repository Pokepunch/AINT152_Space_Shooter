using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroySpawnPowerup : MonoBehaviour {

    public GameObject powerup;
    public float dropChance = 0.8f;

    public void SpawnPowerup()
    {
        if (Random.value >= dropChance)
        {
            Instantiate(powerup, transform.position, transform.rotation);
        }
    }
}
