using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpeedHUDController : MonoBehaviour {

    public Vector2 previousSpeed;
    public Vector2 newSpeed;

    private bool cooldown = false;
    private bool ignoreFirstCall = true;

    public GameObject upArrow;
    public GameObject downArrow;

    private Image speedImage;

    public int flashTimes = 4;
    private int flash;

    public float flashDelay = 0.4f;

	void Start ()
    {
        LevelController.OnScrollSpeedChange += StartMove;
        speedImage = GetComponent<Image>();
	}

    private void StartMove(Vector2 nSpeed)
    {
        if (ignoreFirstCall)
        {
            ignoreFirstCall = false;
        }
        else if (!cooldown)
        {
            previousSpeed = StaticVariables.scrollSpeed;
            newSpeed = nSpeed;
            cooldown = true;
            MoveIntoView();
            Invoke("ResetCooldown", 4);
        }
    }

    private void MoveIntoView()
    {
        speedImage.rectTransform.anchoredPosition = new Vector2(speedImage.rectTransform.anchoredPosition.x + 1f, speedImage.rectTransform.anchoredPosition.y);
        if (speedImage.rectTransform.anchoredPosition.x < -275)
        {
            Invoke("MoveIntoView", 0.01f);
        }
        else
        {
            UpDownCheck();
        }
    }

    private void MoveOutOfView()
    {
        speedImage.rectTransform.anchoredPosition = new Vector2(speedImage.rectTransform.anchoredPosition.x - 1f, speedImage.rectTransform.anchoredPosition.y);
        if (speedImage.rectTransform.anchoredPosition.x > -346)
        {
            Invoke("MoveOutOfView", 0.01f);
        }
    }

    private void UpDownCheck()
    {
        if (newSpeed.x < previousSpeed.x)
        {
            SpeedDown();
        }
        else
        {
            SpeedUp();
        }
    }
	
    private void SpeedUp()
    {
        if (flash < flashTimes)
        {
            if (upArrow.activeSelf)
            {
                upArrow.SetActive(false);
                flash += 1;
                Invoke("SpeedUp", flashDelay / 2);
            }
            else
            {
                upArrow.SetActive(true);
                Invoke("SpeedUp", flashDelay);
            }
        }
        else
        {
            upArrow.SetActive(false);
            MoveOutOfView();
            flash = 0;
        }
    }

    private void SpeedDown()
    {
        if (flash < flashTimes)
        {
            if (downArrow.activeSelf)
            {
                downArrow.SetActive(false);
                flash += 1;
                Invoke("SpeedDown", flashDelay / 2);
            }
            else
            {
                downArrow.SetActive(true);
                Invoke("SpeedDown", flashDelay);
            }
        }
        else
        {
            downArrow.SetActive(false);
            MoveOutOfView();
            flash = 0;
        }
    }

    private void ResetCooldown()
    {
        cooldown = false;
    }
}
