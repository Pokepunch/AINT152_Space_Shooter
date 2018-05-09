using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehavior : MonoBehaviour {

    public GameObject[] linkedMines;

    public string[] damageTags;

    public float explodeDelay = 0.3f;

    public int explosionDamage;

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
            Debug.Log(collision.gameObject.tag);
            MineExplode(null);
        }
    }

    public void MineExplode(GameObject caller)
    {
        foreach (GameObject mine in linkedMines)
        {
            if (mine != caller)
            {
                mine.SendMessage("MineExplode", gameObject);
                Debug.Log(gameObject.name + "Message sent");
            }
        }
        if (caller != null)
        {
            Invoke("SendTakeDamage", explodeDelay);
        }
        else
        {
            Invoke("SendTakeDamage", 0.01f);
        }
    }

    private void SendTakeDamage()
    {
        SendMessage("TakeDamage", 1);
    }
}
