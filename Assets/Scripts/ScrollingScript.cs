using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour {

    public Vector2 Speed = new Vector2(0, 1);
    public Vector2 Direction = new Vector2(0, -1);

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 Movement = new Vector3(Speed.x * Direction.x, Speed.y * Direction.y, 0f);
        Movement *= Time.deltaTime;
        transform.Translate(Movement);
    }
}
