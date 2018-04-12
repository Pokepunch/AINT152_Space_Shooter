using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class destroys the GameObject after the animation it's running has ended.
/// </summary>
public class AnimateDestroy : MonoBehaviour
{
    public AnimationClip anim;

	void Start ()
    {
        Invoke("Kill", anim.length);	
	}
	
    private void Kill()
    {
        Destroy(gameObject);
    }
}
