using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weap01Bullet1 : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explodeTime = 0.5f;

	void Start ()
    {
        Invoke("Explode", explodeTime);
    }
	
    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        CancelInvoke("Explode");
    }
}
