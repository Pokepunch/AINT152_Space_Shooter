using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public delegate void ScrollSpeedChange(Vector2 speed, Vector2 direction);
    public static event ScrollSpeedChange OnScrollSpeedChange;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
