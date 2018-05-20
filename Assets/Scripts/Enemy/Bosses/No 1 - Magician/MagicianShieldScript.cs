using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianShieldScript : MonoBehaviour
{
    public bool cooldown;

    private Transform magician;
    private Color color;
    private GameObject wand;

    private int choice;
    private int previousChoice;

    public float fadeIncrement = 0.1f;

    // Use this for initialization
    void Start()
    {
        magician = transform.parent.transform;
        color = magician.gameObject.GetComponent<SpriteRenderer>().color;
        wand = magician.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetCooldown()
    {
        cooldown = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player Bullets") && !cooldown)
        {
            cooldown = true;
            Invoke("ResetCooldown", 3f);
            while (choice == previousChoice)
            {
                choice = UnityEngine.Random.Range(1, 5);
            }
            previousChoice = choice;
            Debug.Log("OnTriggerStay2D = " + choice);
            if(MagicianWandController.behaviour != 3 && MagicianWandController.behaviour != 4 && MagicianWandController.behaviour != 1)
            {
                switch (choice)
                {
                    case 1:
                        {
                            magician.SendMessage("SetNotRunning");
                            magician.gameObject.GetComponent<Collider2D>().enabled = false;
                            wand.SendMessage("SpawnFlashes");
                            FadeOut();
                            break;
                        }
                    case 2:
                        {
                            Destroy(collision.gameObject);
                            break;
                        }
                    case 3:
                        {
                            wand.SendMessage("SetTarget", collision.transform.gameObject);
                            break;
                        }
                    case 4:
                        {
                            wand.SendMessage("SetBehavior", 3);
                            break;
                        }
                }
            }
        }
    }

    public void FadeOut()
    {
        Color temp = magician.gameObject.GetComponent<SpriteRenderer>().color;
        if (temp.a != 0)
        {
            temp.a -= fadeIncrement;
            temp.a = (float)Math.Round(temp.a, 1);
            magician.gameObject.GetComponent<SpriteRenderer>().color = temp;
            Invoke("FadeOut", 0.1f);
        }
        else
        {
            FadeOutComplete();
        }
    }

    public void FadeOutComplete()
    {
        if (magician.position.y < 0)
        {
            magician.position = new Vector2(magician.position.x, 7);
        }
        else if (magician.position.y > 0)
        {
            magician.position = new Vector2(magician.position.x, -7);
        }
        else
        {
            int i = UnityEngine.Random.Range(1, 3);
            if (i == 1)
            {
                magician.position = new Vector2(magician.position.x, 7);
            }
            else
            {
                magician.position = new Vector2(magician.position.x, -7);
            }
        }
        FadeIn();
    }

    public void FadeIn()
    {
        Color temp = magician.gameObject.GetComponent<SpriteRenderer>().color;
        if (temp.a != 1)
        {
            temp.a += fadeIncrement;
            temp.a = (float)Math.Round(temp.a, 1);
            magician.gameObject.GetComponent<SpriteRenderer>().color = temp;
            Invoke("FadeIn", 0.1f);
        }
        else
        {
            cooldown = true;
            Invoke("ResetCooldown", 5f);
            magician.SendMessage("Begin");
            magician.gameObject.GetComponent<Collider2D>().enabled = true; ;
            magician.GetComponent<MagicianMovementScript>().moveRountine = 0;
        }
    }
}
