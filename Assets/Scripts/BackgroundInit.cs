using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInit : MonoBehaviour {

    public Sprite[] tiles;
    public GameObject backgroundObject;
    public Camera cam;
    GameObject background_1;
    GameObject background_2;

    void Awake ()
    {
        background_1 = Instantiate(backgroundObject, new Vector3(.0f,.1f,.0f), new Quaternion(.0f,.0f,.0f,.0f));
        background_1.GetComponent<SpriteRenderer>().sprite = tiles[0];
        background_2 = Instantiate(backgroundObject, new Vector3(.0f, background_1.transform.position.y + background_1.GetComponent<SpriteRenderer>().bounds.size.y), new Quaternion(.0f, .0f, .0f, .0f));
        background_2.GetComponent<SpriteRenderer>().sprite = tiles[1];
    }
	
	// Update is called once per frame
	void Update()
    {
        UpdateBackground(background_1);
        UpdateBackground(background_2);
    }

    void UpdateBackground(GameObject background)
    {
        if (!background.GetComponent<SpriteRenderer>().isVisible)
        {
            if (background.transform.position.y < cam.transform.position.y)
            {
                background.transform.position = new Vector3(.0f, background.transform.position.y + (2 * background.GetComponent<SpriteRenderer>().bounds.size.y), .0f);
            }
        }
    }
}
