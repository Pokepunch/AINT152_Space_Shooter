using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLooping : MonoBehaviour {

    Camera cam;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < cam.transform.position.x - transform.GetComponent<SpriteRenderer>().bounds.size.x)
        {
            transform.position = new Vector3(transform.position.x + (2 * GetComponent<SpriteRenderer>().bounds.size.x), .0f, .0f);
        }
    }
}
