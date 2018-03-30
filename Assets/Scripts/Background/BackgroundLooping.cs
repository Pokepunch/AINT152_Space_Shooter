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
        if (transform.position.y < cam.transform.position.y - transform.GetComponent<SpriteRenderer>().bounds.size.y)
        {
            transform.position = new Vector3(.0f, transform.position.y + (2 * GetComponent<SpriteRenderer>().bounds.size.y), .0f);
        }
    }
}
