using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour {

    public float multiplier = 1f;
    public Vector2 speed = new Vector2(0, 0);
    public Vector2 direction = new Vector2(-1, 0);

    // Use this for initialization
    void Start ()
    {
        LevelController.OnScrollSpeedChange += SpeedChange;
        LevelController.OnScrollDirectionChange += DirectionChange;
        speed *= multiplier;
    }

    private void OnDisable()
    {
        LevelController.OnScrollSpeedChange -= SpeedChange;
        LevelController.OnScrollDirectionChange -= DirectionChange;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        Vector3 Movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0f);
        Movement *= Time.deltaTime;
        transform.Translate(Movement);
    }

    public void SpeedChange(Vector2 newSpeed)
    {
        speed = newSpeed * multiplier;
    }

    public void DirectionChange(Vector2 newDirection)
    {
        direction = newDirection;
    }
}
