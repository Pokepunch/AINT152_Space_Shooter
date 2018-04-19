using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public delegate void ScrollSpeedChange(Vector2 speed, Vector2 direction);
    public static event ScrollSpeedChange OnScrollSpeedChange;

	void Awake ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            StaticVariables.gamePaused = !StaticVariables.gamePaused;
        }
        if (StaticVariables.gamePaused)
        {
            Time.timeScale = 0;
        }
        else if (!StaticVariables.gamePaused)
        {
            Time.timeScale = 1;
        }
    }
}
