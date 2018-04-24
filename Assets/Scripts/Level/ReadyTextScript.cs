using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ReadyTextScript : MonoBehaviour
{
    public GameObject readyText;
    public Image fillWhite;

    private bool done = false;

	// Use this for initialization
	void Start ()
    {
        FadeInControllerScript.FadeComplete += ReadyStart;
	}

    void ReadyStart()
    {
        fillWhite.fillAmount += 0.04f;
        if (fillWhite.fillAmount >= 1.0f)
        {
            readyText.SetActive(!readyText.activeSelf);
            ChangeFillOrigin();
            Invoke("ReadyMiddle", 0.01f);
        }
        else
        {
            Invoke("ReadyStart", 0.01f);
        }
    }

    void ReadyMiddle()
    {
        fillWhite.fillAmount -= 0.04f;
        if (fillWhite.fillAmount <= 0.0f)
        {
            if (!done)
            {
                done = true;
                ChangeFillOrigin();
                Invoke("ReadyStart", 1.5f);
            }
            else
            {
                GameObject introControll = GameObject.Find("Level Intro Controller");
                introControll.SendMessage("IntroStart");
            }
        }
        else
        {
            Invoke("ReadyMiddle", 0.01f);
        }
    }

    void ChangeFillOrigin()
    {
        if (fillWhite.fillOrigin == 1)
        {
            fillWhite.fillOrigin = 0;
        }
        else
        {
            fillWhite.fillOrigin = 1;
        }
    }
}
