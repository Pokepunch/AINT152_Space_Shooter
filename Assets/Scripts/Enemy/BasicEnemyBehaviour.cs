using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehaviour : MonoBehaviour
{
    public int damage = 2;

    private Camera cam;
    private Rigidbody2D body;

    public bool onScreen = false;

    void Start()
    {
        cam = Camera.main;
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            body.isKinematic = true;
        }
        Damage(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Damage(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            body.isKinematic = false;
        }
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
