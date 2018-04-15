using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect_ButtonScript : MonoBehaviour
{
    public void OnClick(int levelIndex)
    {
        SceneManager.LoadScene("SpaceShooterLevel");
        SceneManager.LoadScene("Level" + levelIndex, LoadSceneMode.Additive);
    }
}
