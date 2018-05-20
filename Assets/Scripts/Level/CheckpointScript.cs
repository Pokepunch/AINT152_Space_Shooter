using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public int section = 2;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (transform.position.x <= 0)
        {
            SceneManager.LoadScene("Level" + StaticVariables.levelIndex + "-" + section, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Level" + StaticVariables.levelIndex + "-" + (section - 1));
            StaticVariables.levelSection++;
        }
	}
}
