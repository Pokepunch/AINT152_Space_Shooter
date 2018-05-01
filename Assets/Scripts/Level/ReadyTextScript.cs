using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ReadyTextScript : MonoBehaviour
{
    public GameObject readyText;
    public GameObject white;
    private Image fillWhite;

    private bool done = false;
    private bool startCalled = false;

	// Use this for initialization
	void Start ()
    {
        fillWhite = white.GetComponent<Image>();
        FadeInControllerScript.FadeComplete += ReadyStart;
        Invoke("FadeBackupStart", 3);
	}

    /// <summary>
    /// If the fade in object isn't present this function will start the the script without it.
    /// </summary>
    private void FadeBackupStart()
    {
        if (!startCalled)
        {
            ReadyStart();
            FadeInControllerScript.FadeComplete -= ReadyStart;
        }
    }


    private void OnDisable()
    {
        FadeInControllerScript.FadeComplete -= ReadyStart;
    }

    void ReadyStart()
    {
        startCalled = true;
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
                done = false;
                GameObject introControl = GameObject.Find("Level Intro Controller");
                introControl.SendMessage("IntroStart");
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
