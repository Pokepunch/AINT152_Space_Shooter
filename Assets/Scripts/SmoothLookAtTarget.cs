using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAtTarget : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;
    public float snapAngle = 45.0f;

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 difference = target.position - transform.position;
            difference.Normalize();
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            rotZ = Mathf.Round(rotZ / snapAngle) * snapAngle;
            Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ -90));
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);
        }
    }
}
