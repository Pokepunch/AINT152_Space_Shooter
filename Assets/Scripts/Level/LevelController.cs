using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public delegate void ScrollSpeedChange(Vector2 x);
    public static event ScrollSpeedChange OnScrollSpeedChange;
    public static event ScrollSpeedChange OnScrollDirectionChange;

    private void OnEnable()
    {
        ChangeScrollSpeed(new Vector2(1, 0));
        ChangeScrollDirection(new Vector2(-1, 0));
    }

    public void ChangeScrollSpeed(Vector2 newSpeed)
    {
        if (OnScrollSpeedChange != null)
        {
            OnScrollSpeedChange(newSpeed);
        }
    }

    public void ChangeScrollDirection(Vector2 newDirection)
    {
        if (OnScrollDirectionChange != null)
        {
            OnScrollDirectionChange(newDirection);
        }
    }

    // Update is called once per frame
    void Update ()
    {

    }
}
