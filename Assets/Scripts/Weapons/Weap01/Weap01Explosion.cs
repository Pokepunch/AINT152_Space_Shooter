using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weap01Explosion : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float disperseAngle;

    // Use this for initialization
    void Start ()
    {
        Invoke("SplitBullet", 0.125f);
	}

    private void SplitBullet()
    {
        Quaternion rot1 = Quaternion.Euler(transform.rotation.x, transform.rotation.y, disperseAngle - 90);
        Quaternion rot2 = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -disperseAngle - 90);
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        Instantiate(bulletPrefab, transform.position, rot1);
        Instantiate(bulletPrefab, transform.position, rot2);
        Debug.Log(transform.rotation.z + " " + rot1.z);
    }
}
