using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianWandController : MonoBehaviour
{
    public delegate void WandMoveEvent();
    public static event WandMoveEvent MoveFinishedEvent;

    private GameObject magician;
    private GameObject player;
    public GameObject barrier;

    public GameObject flashPrefab;
    public float[] flashOffsets;
    public int flashCount = -1;

    public float lerpAmount;
    public float lerpIncrement = 0.02f;
    public float speed = 10;

    public static int? behaviour = null;
    private bool moving = false;

    public float targetX = -18;
    public float targetY = 10;

    private bool isSpinning = false;
    public float rotationAmount;

    private int circleLoop;

    private bool bossStarted = false;

    public Vector2 savedPos;
    public GameObject bullet;
    public Vector2? targetPos;
    public Vector2? curvePos;

    void Start ()
    {
        BossIntroScript.IntroStart += WandIntro;
        BossIntroScript.IntroEnd += WandBehaviourStart;

        magician = transform.parent.gameObject;
        player = GameObject.Find("Hero");

        flashOffsets = new float[]
        {
            0, 0,
            0, 1,
            1, 0,
            1, 1
        };
    }
	
    public void WandIntro()
    {
        WandMove(new Vector2(-3.5f, 0));
        MoveFinishedEvent += WandIntro2;
    }

    public void WandIntro2()
    {
        MoveFinishedEvent -= WandIntro2;
        WandMove(new Vector2(-3.5f, 3.5f));
        WandSpin();
        SpawnFlashes();
        MoveFinishedEvent += WandIntro3;
    }

    public void WandIntro3()
    {
        MoveFinishedEvent -= WandIntro3;
        curvePos = new Vector2(-10, 0);
        WandMove(new Vector2(-3.5f, -3.5f));
        MoveFinishedEvent += WandIntro4;
    }

    public void WandIntro4()
    {
        MoveFinishedEvent -= WandIntro4;
        WandMove(new Vector2(-3.5f, 5.0f));
        MoveFinishedEvent += WandIntroEnd;
    }

    public void WandIntroEnd()
    {
        MoveFinishedEvent -= WandIntroEnd;
        GameObject.Find("Boss Intro").SendMessage("EndIntro");
        transform.parent = null;
        MoveFinishedEvent += SetNotMoving;
    }

    private void FixedUpdate()
    {
        if (behaviour != null)
        {
            GetBehavoir();
        }
        else if (bossStarted && !moving)
        {
            MoveTopScreen();
        }
        if (targetPos != null)
        {
            if (curvePos == null)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, (Vector2)targetPos, speed * Time.deltaTime);
            }
            else
            {
                lerpAmount += lerpIncrement;
                transform.localPosition = Vector2Extention.LerpCurve(savedPos, (Vector2)curvePos, (Vector2)targetPos, lerpAmount);
                lerpAmount = (float)Math.Round(lerpAmount, 2);
            }
            if ((Vector2)transform.localPosition == targetPos)
            {
                targetPos = null;
                curvePos = null;
                lerpAmount = 0;
                if (MoveFinishedEvent != null)
                {
                    MoveFinishedEvent();
                }
            }
        }
        if (isSpinning)
        {
            if (rotationAmount < 0)
            {
                rotationAmount = 0;
            }
            rotationAmount += 15f;
            if (rotationAmount >= 360)
            {
                rotationAmount = 0;
            }
            if (rotationAmount % 45 == 0)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotationAmount));
            }
        }
    }

    public void MoveTopScreen()
    {
        targetPos = new Vector2(targetX, targetY);
        targetX *= -1;
        moving = true;
    }

    public void SetBehavior(int i)
    {
        behaviour = i;
    }

    public void SetBehavior()
    {
        behaviour = null;
    }

    public void SetTarget(GameObject pos)
    {
        bullet = pos;
        behaviour = 2;
    }

    public void GetBehavoir()
    {
        if (behaviour == 0)
        {
            behaviour = UnityEngine.Random.Range(1, 5);
        }
        Debug.Log("GetBehaviour = " + behaviour);
        switch (behaviour)
        {
            case 1:
                {
                    break;
                }
            case 2:
                {
                    SpawnFlash(0,0);
                    WandStopSpin(90);
                    targetPos = null;
                    transform.localPosition = bullet.transform.position;
                    SpawnFlashes();
                    Invoke("WandSpin", 0.3f);
                    Invoke("SetBehavior", 0.5f);
                    Invoke("SetNotMoving", 0.5f);
                    behaviour = null;
                    WandBlockAction();
                    break;
                }
            case 3:
                {
                    moving = true;
                    behaviour = 4;
                    break;
                }
            case 4:
                {
                    if (moving)
                    {
                        targetPos = new Vector2(player.transform.position.x + 3.5f, player.transform.position.y);
                    }
                    else if (!moving)
                    {
                        targetPos = null;
                        moving = true;
                        behaviour = 1;
                        transform.parent = player.transform;
                        transform.localPosition = new Vector2(0, 2);
                        WandStopSpin(0);
                        SpawnFlashes();
                        Invoke("CircleStart", 2);
                    }
                    break;
                }
        }
    }

    public void WandBlockAction()
    {
        int action = UnityEngine.Random.Range(0, 2);
        Debug.Log("WandBlockAction = " + action);
        switch (action)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    Debug.Log(bullet.name);
                    GameObject reflectbullet = Instantiate(bullet, transform.position, Quaternion.Euler(0,0, 90));
                    reflectbullet.GetComponent<BulletHit2D>().damageTag = new string[] { "Player" };
                    break;
                }
        }
    }

    public void CircleStart()
    {
        MoveFinishedEvent -= CircleStart;
        SpawnFlash(0, 0);
        if (circleLoop < 1)
        {
            WandSpin();
            SpawnFlashes();
        }
        if (circleLoop > 4)
        {
            lerpIncrement = 0.02f;
            transform.parent = null;
            circleLoop = 0;
            moving = false;
            behaviour = null;
            SpawnCircle();
        }
        else
        {
            circleLoop++;
            lerpIncrement += 0.03f;
            curvePos = new Vector2(-2, 2);
            WandMove(new Vector2(-2, 0));
            MoveFinishedEvent += Circle2;
        }
    }

    public void Circle2()
    {
        MoveFinishedEvent -= Circle2;
        curvePos = new Vector2(-2, -2);
        WandMove(new Vector2(0, -2));
        SpawnFlash(0, 0);
        MoveFinishedEvent += Circle3;
    }

    public void Circle3()
    {
        MoveFinishedEvent -= Circle3;
        curvePos = new Vector2(2, -2);
        WandMove(new Vector2(2, 0));
        SpawnFlash(0,0);
        MoveFinishedEvent += Circle4;
    }

    public void Circle4()
    {
        MoveFinishedEvent -= Circle4;
        curvePos = new Vector2(2, 2);
        WandMove(new Vector2(0, 2));
        SpawnFlash(0, 0);
        MoveFinishedEvent += CircleStart;
    }

    public void SetNotMoving()
    {
        moving = false;
    }

    public void WandBehaviourStart()
    {
        bossStarted = true;
    }

    public void WandMove(Vector2 target)
    {
        savedPos = transform.localPosition;
        targetPos = target;
    }

    public void WandSpin()
    {
        isSpinning = true;
    }

    public void WandStopSpin(float? angle = null)
    {
        if (angle != null)
        {
            transform.localRotation = Quaternion.Euler(0,0,(float)angle);
            rotationAmount = (float)angle;
        }
        isSpinning = false;
    }

    public void SpawnCircle()
    {
        barrier.transform.position = player.transform.position;
        barrier.SetActive(true);
    }

    public void SpawnFlashes()
    {
        flashCount++;
        SpawnFlash(flashOffsets[flashCount], flashOffsets[flashCount+1]);
        flashCount++;
        if (flashCount != 7)
        {
            Invoke("SpawnFlashes", 0.05f);
        }
        else
        {
            flashCount = -1;
        }
    }

    public void SpawnFlash(float offsetX, float offsetY)
    {
        Instantiate(flashPrefab, new Vector2(transform.position.x + offsetX, transform.position.y + offsetY), transform.localRotation);
    }
}
