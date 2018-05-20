using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerEnterTrigger : MonoBehaviour
{
    public int damage = 4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.SendMessage("TakeDamage", damage);
        }
    }
}
