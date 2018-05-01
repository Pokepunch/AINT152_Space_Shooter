using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehaviour : MonoBehaviour
{
    public int damage = 2;

    private Camera cam;

    public bool onScreen = false;

    void Start()
    {
        cam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Damage(collision);
    }

    private void Damage(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.SendMessage("TakeDamage", damage);
        }
    }

    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x < 0)
        {
            Destroy(gameObject);
        }
        if (viewPos.x < 1)
        {
            onScreen = true;
        }
    }
}
