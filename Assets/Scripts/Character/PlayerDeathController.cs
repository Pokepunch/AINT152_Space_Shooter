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
        FadeOutControllerScript.FadeComplete -= LoadScenes;
    }

    private void OnDeath()
    {
        StaticVariables.controlLock = true;
        SceneManager.LoadScene("FadeOutScene", LoadSceneMode.Additive);
        GameObject LevelControl = GameObject.Find("LevelController");
        LevelControl.GetComponent<LevelController>().ChangeScrollSpeed(Vector2.zero);
        FadeOutControllerScript.FadeComplete += LoadScenes;
    }

    private void LoadScenes()
    {
        SceneManager.LoadScene("SpaceShooterLevel");
        SceneManager.LoadScene("FadeInScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level" + StaticVariables.levelIndex, LoadSceneMode.Additive);
        SceneManager.LoadScene("Level" + StaticVariables.levelIndex + "-" + StaticVariables.levelSection, LoadSceneMode.Additive);
    }
}
