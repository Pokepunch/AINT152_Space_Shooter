using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehavior : MonoBehaviour {

    public GameObject[] linkedMines;
    public GameObject explosion;

    public GameObject callingMine = null;

    public string[] damageTags;
    public float explodeDelay = 0.3f;
    public int explosionDamage;

    private bool isExploding = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Mine"))
        {
            foreach (string tag in damageTags)
            {
                if (collision.gameObject.CompareTag(tag))
                {
                    collision.gameObject.SendMessage("TakeDamage", 4);
                }
            }
            TriggerExplosion(null);
        }
    }

    public void TriggerExplosion(GameObject caller)
    {
        callingMine = caller;
        if (!isExploding)
        {
            isExploding = true;
            if (callingMine != null)
            {
                Invoke("Explode", explodeDelay);
            }
            else
            {
                Explode();
            }
        }
    }

    public void Explode()
    {
        foreach (GameObject mine in linkedMines)
        {
            if (mine != null)
            {
                mine.SendMessage("TriggerExplosion", gameObject);
            }
        }
        GameObject explo = Instantiate(explosion, transform.position, transform.rotation);
        explo.GetComponent<CircleCollider2D>().enabled = true;
        Destroy(gameObject);
    }

    public void TakeDamage(int damage = 1)
    {
        TriggerExplosion(null);
    }
}
