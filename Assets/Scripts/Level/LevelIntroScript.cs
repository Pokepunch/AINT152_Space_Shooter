using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelIntroScript : MonoBehaviour
{
    public Image hud;
    public float playerStartPos = -15;

    public GameObject Player;

    public void IntroStart()
    {
        Player.GetComponent<TopDownCharacterController2D>().PlayerMove(1, 0);
    }

    public void MoveHUD()
    {
        hud.rectTransform.anchoredPosition = new Vector2(hud.rectTransform.anchoredPosition.x + 0.5f, hud.rectTransform.anchoredPosition.y);
        if (hud.rectTransform.anchoredPosition.x < -295)
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
	void FixedUpdate ()
    {
        if (Player.transform.position.x >= playerStartPos)
        {
            Player.GetComponent<TopDownCharacterController2D>().PlayerMove(0, 0);
            StaticVariables.controlLock = false;
            Player.GetComponent<BoxCollider2D>().enabled = true;
            MoveHUD();
        }
    }
}
