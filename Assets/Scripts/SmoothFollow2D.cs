using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour
{
    public Transform player;
    private float scrollSpeed = 0.05f;
    public float ScrollSpeed { get; set; }
    public float Width;
    public float Height;

    private void Start()
    {
        Camera cam = GetComponent<Camera>();
        Height = Screen.height;
        Width = Screen.width;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, (float)Math.Round(transform.position.y, 2) + scrollSpeed, transform.position.z);
        // Keep Player with the camera.
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + scrollSpeed, player.transform.position.z);
    }
}
