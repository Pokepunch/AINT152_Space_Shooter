using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2D : MonoBehaviour {

    public float speed = 5.0f;

    void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    private void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x < 0 || viewPos.x > 1)
        {
            Die();
        }
    }
}
