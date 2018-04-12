using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour {

    public float multiplier = 1f;
    public Vector2 speed = new Vector2(0, 1);
    public Vector2 direction = new Vector2(0, -1);

    // Use this for initialization
    void Start ()
    {
        LevelController.OnScrollSpeedChange += ScrollChange;
        speed *= multiplier;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 Movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0f);
        Movement *= Time.deltaTime;
        transform.Translate(Movement);
    }

    public void ScrollChange(Vector2 newSpeed, Vector2 newDirection)
    {
        Debug.Log(this.gameObject.name + ": ScrollChange received");
        speed = newSpeed * multiplier;
        direction = newDirection;
    }
}
