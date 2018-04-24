using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class FadeOutControllerScript : MonoBehaviour {

    public delegate void FadeOutControl();
    public static event FadeOutControl FadeComplete;

    public Image image;
    public float startDelay;
    public float fadeAmount;

    public int fadeTarget;

	// Use this for initialization
	void Start ()
    {
        if (fadeAmount < 0)
        {
            fadeTarget = 0;
        }
        else
        {
            fadeTarget = 1;
        }
        Invoke("FadeImage", startDelay);
	}

    void FadeImage()
    {
        Color _temp = image.color;
        float i = (float)Math.Round(_temp.a += fadeAmount, 2);
        _temp.a = i;
        image.color = _temp;
        if (image.color.a != fadeTarget)
        {
            Invoke("FadeImage", 0.05f);
        }
        else
        {
            if (FadeComplete != null)
            {
                FadeComplete();
            }
        }
    }
}
