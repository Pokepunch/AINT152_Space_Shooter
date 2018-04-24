using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameScript : MonoBehaviour
{
    public delegate void OnGamePaused();
    public static event OnGamePaused GamePaused;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Cancel") && StaticVariables.controlLock == false)
        {
            StaticVariables.gamePaused = !StaticVariables.gamePaused;
            if (GamePaused != null)
            {
                GamePaused();
            }
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
