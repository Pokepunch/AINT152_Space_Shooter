using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject[] enemyList;

    private Vector2 savedSpeed;

    private void Start()
    {
        LevelController.OnScrollSpeedChange += SpeedChange;
    }

    public void SpeedChange(Vector2 newSpeed)
    {
        savedSpeed = newSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject enemy in enemyList)
            {
                enemy.SetActive(true);
                enemy.GetComponent<ScrollingScript>().speed = savedSpeed;
            }
        }
    }

}
