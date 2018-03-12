using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour
{
    public Transform player;
    private float scrollSpeed = 0.05f;
    public float ScrollSpeed { get; set; }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + scrollSpeed, transform.position.z);
        // Keep Player with the camera.
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + scrollSpeed, player.transform.position.z);
    }
}
