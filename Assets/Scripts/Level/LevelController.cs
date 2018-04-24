using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public delegate void ScrollSpeedChange(Vector2 speed, Vector2 direction);
    public static event ScrollSpeedChange OnScrollSpeedChange;

	void Awake ()
    {

	}

    private void OnEnable()
    {
        OnScrollSpeedChange(new Vector2(1, 0), new Vector2(-1, 0));
    }

    // Update is called once per frame
    void Update ()
    {

    }
}
