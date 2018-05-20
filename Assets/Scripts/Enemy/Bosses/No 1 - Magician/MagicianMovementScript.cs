using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianMovementScript : MonoBehaviour
{
    // Used to determine if the boss is active.
    private bool isRunning = false;

    // Used to determine if RerollMove has been Invoked so that it doesn't get invoked again.
    private bool rerollInvoked = false;

    // moveRoutine controls what movements the boss is making.
    // 0 - Nothing
    // 1 - Moving up to maxHeight
    // 2 - Moving down to minHeight
    // 3 - Moving to y = 0.
    public int moveRountine;

    // The previous movement the boss made. Used to prevent repitition.
    public int previousMove;

    public float speed = 6;

    // Max and Minimum height the boss can go.
    public float maxHeight = 9;
    public float minHeight = -9;

	// Use this for initialization
	void Start ()
    {
        RerollMove();
        BossIntroScript.IntroEnd += Begin;
	}

    // Get the boss going.
    public void Begin()
    {
        isRunning = true;
    }

    // Used to stop the boss moving.
    public void SetNotRunning()
    {
        isRunning = false;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (isRunning)
        {
            // This switch statement determines which movement the boss will make.
            // The possibilities are listed above.
            switch (moveRountine)
            {
                case 0:
                    {
                        if (!rerollInvoked)
                        {
                            Invoke("RerollMove", 0.3f);
                            rerollInvoked = true;
                        }
                        break;
                    }
                case 1:
                    {
                        if (transform.position.y < maxHeight)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, maxHeight), speed * Time.deltaTime);
                        }
                        else
                        {
                            RerollMove();
                        }
                        break;
                    }
                case 2:
                    {
                        if (transform.position.y > minHeight)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, minHeight), speed * Time.deltaTime);
                        }
                        else
                        {
                            RerollMove();
                        }
                        break;
                    }
                case 3:
                    {
                        if (transform.position.y > 0)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 0), speed * Time.deltaTime);
                        }
                        else
                        {
                            RerollMove();
                        }
                        break;
                    }
            }
        }
	}

    // Gets a random number for moveRoutine, doesn't allow repeats of a movement in a row which prevents some awkward movements.
    public void RerollMove()
    {
        while (moveRountine == previousMove)
        {
            moveRountine = Random.Range(0, 4);
        }
        previousMove = moveRountine;
        rerollInvoked = false;
    }
}
