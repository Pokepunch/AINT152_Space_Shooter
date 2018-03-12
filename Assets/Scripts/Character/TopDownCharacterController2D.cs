using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour
{
    // Fields and Properties
    public float speed = 5.0f;
    Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rigidbody2D.velocity = new Vector2(Mathf.Round(x),Mathf.Round(y)) * speed;
        rigidbody2D.angularVelocity = 0.0f;
	}
}
