﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    public Sprite[] tiles;
    public GameObject backgroundObject;
    public float test;
    GameObject background_1;
    GameObject background_2;
    public Camera cam;

    void Awake ()
    {
        background_1 = Instantiate(backgroundObject, Vector3.zero, new Quaternion(.0f,.0f,.0f,.0f));
        background_1.GetComponent<SpriteRenderer>().sprite = tiles[0];
        background_2 = Instantiate(backgroundObject, new Vector3(.0f, background_1.transform.position.y + background_1.GetComponent<SpriteRenderer>().bounds.size.y), new Quaternion(.0f, .0f, .0f, .0f));
        background_2.GetComponent<SpriteRenderer>().sprite = tiles[1];
    }
	
	// Update is called once per frame
	void Update ()
    {
        test = cam.transform.position.y;
	}
}