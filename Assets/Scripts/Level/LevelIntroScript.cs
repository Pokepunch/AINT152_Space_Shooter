using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelIntroScript : MonoBehaviour
{
    public Image healthBar;
    public float playerStartPos = -15;

    private GameObject Player;
    public bool shouldMovePlayer = false;

    public void Start()
    {
        Player = GameObject.Find("Hero");
    }

    public void IntroStart()
    {
        shouldMovePlayer = true;
        Player.GetComponent<TopDownCharacterController2D>().PlayerMove(1, 0);
    }

    public void MoveHUD()
    {
        healthBar.rectTransform.anchoredPosition = new Vector2(healthBar.rectTransform.anchoredPosition.x + 0.5f, healthBar.rectTransform.anchoredPosition.y);
        if (healthBar.rectTransform.anchoredPosition.x < -295)
        {
            Invoke("MoveHUD", 0.01f);
        }
        else
        {
            GameObject LevelController = GameObject.Find("LevelController");
            LevelController.GetComponent<LevelController>().enabled = true;
            Scene fade = SceneManager.GetSceneByName("FadeInScene");
            if (fade.isLoaded)
            {
                SceneManager.UnloadSceneAsync("FadeInScene");
            }
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Player.transform.position.x >= playerStartPos)
        {
            Player.GetComponent<TopDownCharacterController2D>().PlayerMove(0, 0);
            StaticVariables.controlLock = false;
            shouldMovePlayer = false;
            Player.GetComponent<BoxCollider2D>().enabled = true;
            MoveHUD();
        }
    }
}
