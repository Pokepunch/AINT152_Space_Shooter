using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDamage : MonoBehaviour
{
    public int damage = 1;
    public string[] damageTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in damageTag)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                collision.gameObject.SendMessage("TakeDamage", damage);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (string tag in damageTag)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                collision.gameObject.SendMessage("TakeDamage", damage);
            }
        }
    }
}
