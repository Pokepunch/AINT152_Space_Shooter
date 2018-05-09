using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{

    void Start()
    {
        DamageBehaviorPlayer.PlayerDead += OnDeath;
    }

    private void OnDestroy()
    {
        DamageBehaviorPlayer.PlayerDead -= OnDeath;
        FadeOutControllerScript.FadeComplete -= RespawnStart;
    }

    private void OnDeath()
    {
        StaticVariables.controlLock = true;
        SceneManager.LoadScene("FadeOutScene", LoadSceneMode.Additive);
        GameObject LevelControl = GameObject.Find("LevelController");
        LevelControl.GetComponent<LevelController>().ChangeScrollSpeed(Vector2.zero);
        FadeOutControllerScript.FadeComplete += RespawnStart;
    }

    private void RespawnStart()
    {
        if (StaticVariables.playerRespawnPoint == Vector2.zero)
        {
            LoadScenes();
        }
    }

    private void LoadScenes()
    {
        SceneManager.LoadScene("SpaceShooterLevel");
        SceneManager.LoadScene("FadeInScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level" + StaticVariables.levelIndex, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
