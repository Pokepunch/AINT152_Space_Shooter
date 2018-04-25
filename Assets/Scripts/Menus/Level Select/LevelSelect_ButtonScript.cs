using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect_ButtonScript : MonoBehaviour
{
    private void Start()
    {
        FadeInControllerScript.FadeComplete += UnloadFadeIn;
    }

    private void OnDisable()
    {
        FadeInControllerScript.FadeComplete -= UnloadFadeIn;
    }

    public void UnloadFadeIn()
    {
        SceneManager.UnloadSceneAsync("FadeInScene");
    }

    public void OnClick(int levelIndex)
    {
        StaticVariables.levelIndex = levelIndex;
        SceneManager.LoadScene("FadeOutScene", LoadSceneMode.Additive);
        FadeOutControllerScript.FadeComplete += LoadLevels;
    }

    public void LoadLevels()
    {
        SceneManager.LoadScene("SpaceShooterLevel");
        SceneManager.LoadScene("FadeInScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level" + StaticVariables.levelIndex, LoadSceneMode.Additive);
    }
}
