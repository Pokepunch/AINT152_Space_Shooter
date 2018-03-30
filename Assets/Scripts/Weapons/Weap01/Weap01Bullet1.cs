using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weap01Bullet1 : MonoBehaviour {

    public GameObject bulletPrefab;
    public float splitTime = 0.5f;
    private Quaternion rot1;
    private Quaternion rot2;

	void Start ()
    {
        Invoke("SplitBullet", splitTime);
    }
	
    private void SplitBullet()
    {
        rot1 = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 45.0f);
        rot2 = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -45.0f);
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        Instantiate(bulletPrefab, transform.position, rot1);
        Instantiate(bulletPrefab, transform.position, rot2);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        CancelInvoke("SplitBullet");
    }
}
