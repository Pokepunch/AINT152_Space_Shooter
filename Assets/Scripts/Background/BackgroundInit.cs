using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInit : MonoBehaviour
{
    public Sprite[] tiles;
    public GameObject bg_layer0;
    public GameObject bg_layer1;

    void Awake()
    {
        GameObject bg_layer0_1 = Instantiate(bg_layer0, new Vector3(.1f, .0f, .0f), new Quaternion(.0f, .0f, .0f, .0f));
        bg_layer0_1.GetComponent<SpriteRenderer>().sprite = tiles[0];
        GameObject bg_layer0_2 = Instantiate(bg_layer0, new Vector3(bg_layer0_1.transform.position.x + bg_layer0_1.GetComponent<SpriteRenderer>().bounds.size.x, .0f), new Quaternion(.0f, .0f, .0f, .0f));
        bg_layer0_2.GetComponent<SpriteRenderer>().sprite = tiles[0];

        GameObject bg_layer1_1 = Instantiate(bg_layer1, new Vector3(.1f, .0f, .0f), new Quaternion(.0f, .0f, .0f, .0f));
        bg_layer1_1.GetComponent<SpriteRenderer>().sprite = tiles[1];
        GameObject bg_layer1_2 = Instantiate(bg_layer1, new Vector3(bg_layer1_1.transform.position.x + bg_layer1_1.GetComponent<SpriteRenderer>().bounds.size.x, .0f), new Quaternion(.0f, .0f, .0f, .0f));
        bg_layer1_2.GetComponent<SpriteRenderer>().sprite = tiles[1];
    }
}
