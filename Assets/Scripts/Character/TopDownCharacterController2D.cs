﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour
{
    // Fields and Properties
    public float speed = 50.0f;
    Rigidbody2D rigid2D;

	// Use this for initialization
	void Start ()
    {
        rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (!StaticVariables.controlLock)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            PlayerMove(x, y);
        }
	}

    public void PlayerMove(float x, float y)
    {
        rigid2D.velocity = new Vector2(Mathf.Round(x), Mathf.Round(y)) * speed;
        rigid2D.angularVelocity = 0.0f;
    }
}
