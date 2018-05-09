using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DamageBehaviorPlayer : MonoBehaviour
{
    public int health = 10;
    public bool canDamage = true;

    public delegate void OnHealthChanged(int health);
    public static event OnHealthChanged PlayerOnHealthChanged;

    public delegate void OnPlayerDeath();
    public static event OnPlayerDeath PlayerDead;

    int flashCounter;
    float frameTimer;
    bool visible = true;
    public int flashTimes = 4;
    public int flashFrameGap = 12;

    public Material _default;
    public Material white;
    public GameObject Explosion;

    public void TakeDamage(int damage)
    {
        if (flashCounter == 0 && canDamage == true)
        {
            health -= damage;
            if (PlayerOnHealthChanged != null)
            {
                PlayerOnHealthChanged(health);
            }
            Debug.Log(gameObject.name + " damaged. Health is " + health);
            flashCounter = flashTimes;
            if (health <= 0)
            {
                Instantiate(Explosion, transform.position, transform.rotation);
                PlayerDead();
                gameObject.SetActive(false);
            }
        }
    }

    public void RestoreHealth(int amount)
    {
        int _health = health;
        _health += amount;
        if (_health > 10)
        {
            _health = 10;
        }
        health = _health;
        Debug.Log(gameObject.name + " healed. Health is " + health);
        if (PlayerOnHealthChanged != null)
        {
            PlayerOnHealthChanged(health);
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
            GetComponent<SpriteRenderer>().material = _default;
            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<SpriteRenderer>() != null)
                {
                    child.gameObject.GetComponent<SpriteRenderer>().material = _default;
                }
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().material = white;
            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<SpriteRenderer>() != null)
                {
                    child.gameObject.GetComponent<SpriteRenderer>().material = white;
                }
            }
        }
    }
}
