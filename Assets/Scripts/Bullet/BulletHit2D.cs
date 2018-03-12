using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit2D : MonoBehaviour {

    public int damage = 1;
    public string[] damageTag;
    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string tag in damageTag)
        {
            if (other.CompareTag(tag))
            {
                other.SendMessage("TakeDamage", damage);
                Destroy(gameObject);
            }
        }
    }
}
