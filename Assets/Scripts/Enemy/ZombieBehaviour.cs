using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {

    public int health = 10;
    int flashCounter;
    float frameTimer;
    bool visible = true;
    public int flashTimes = 4;
    public int flashFrameGap = 12;

    public void TakeDamage(int damage)
    {
        health -= damage;
        flashCounter = flashTimes;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (flashCounter > 0)
        {
            frameTimer++;
            if (frameTimer % flashFrameGap == 0)
            {
                visible = !visible;
                ToggleVisible(visible);
                if (visible)
                {
                    flashCounter--;
                    if (flashCounter == 0)
                    {
                        frameTimer = 0;
                    }
                }
            }
        }
    }

    private void ToggleVisible(bool visible)
    {
        if (visible == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
