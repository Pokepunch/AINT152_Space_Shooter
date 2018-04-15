using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour
{
    // Fields and Properties
    public float speed = 50.0f;
    private int pixelsPerUnit = 16;
    Transform playerTrans;
    Rigidbody2D rigid2D;

	// Use this for initialization
	void Start ()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        playerTrans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rigid2D.velocity = new Vector2(Mathf.Round(x),Mathf.Round(y)) * speed;
        rigid2D.angularVelocity = 0.0f;
	}
}
