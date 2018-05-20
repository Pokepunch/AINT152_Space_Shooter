using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScrollSpeed : MonoBehaviour
{
    private GameObject lvlController;
    private float speed;
    private bool started = false;

    public float targetSpeed = 3;
    public float speedIncAmount = 0.2f;

    private void Start()
    {
        LevelController.OnScrollSpeedChange += UpdateSpeed;
        lvlController = GameObject.Find("LevelController");
    }

    private void UpdateSpeed(Vector2 newSpeed)
    {
        speed = newSpeed.x;
    }

    private void FixedUpdate()
    {
        if (lvlController.GetComponent<LevelController>().enabled)
        {
            if (transform.position.x <= 0 && !started)
            {
                started = true;
                speed = StaticVariables.scrollSpeed.x;
                ChangeSpeed();
            }
        }
    }

    private void ChangeSpeed()
    {
        if (speed != targetSpeed)
        {
            speed += speedIncAmount;
            speed = (float)Math.Round(speed, 1);
            lvlController.GetComponent<LevelController>().ChangeScrollSpeed(new Vector2(speed, 0));
            Invoke("ChangeSpeed", 0.1f);
        }
    }
}
