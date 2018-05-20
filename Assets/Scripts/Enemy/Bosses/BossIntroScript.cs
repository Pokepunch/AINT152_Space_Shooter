using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntroScript : MonoBehaviour
{
    public delegate void BossIntroEvent();
    public static event BossIntroEvent IntroStart;
    public static event BossIntroEvent IntroEnd;

    private int done = 0;

    public GameObject boss;
	
	// Update is called once per frame
	void Update ()
    {
        if (boss.transform.position.x < 25 && done < 1)
        {
            done = 1;
            StaticVariables.controlLock = true;
            GameObject.Find("Hero").GetComponent<TopDownCharacterController2D>().PlayerMove(0, 0);
        }
        if (boss.transform.position.x < 13.7 && done < 2)
        {
            done = 2;
            Invoke("CallIntro", 0.5f);
        }	
	}

    public void CallIntro()
    {
        if (IntroStart != null)
        {
            IntroStart();
        }
    }

    public void EndIntro()
    {
        StaticVariables.controlLock = false;
        if (IntroEnd != null)
        {
            IntroEnd();
        }
        Destroy(gameObject);
    }
}
