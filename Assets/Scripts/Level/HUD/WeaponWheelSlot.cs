using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponWheelSlot : MonoBehaviour
{
    public Vector3 target = Vector3.zero;
    private Vector2 midpoint;

    public int index;

    public bool is3rdSlot = false;

    public float speed = 0.1f;

    private Image image;
    private Vector3 originalPos;

    private Image weaponImage;
    public Sprite[] weaponSprites;

	// Use this for initialization
	void Start ()
    {
        image = GetComponent<Image>();
        originalPos = image.rectTransform.localPosition;
        weaponImage = transform.GetChild(0).GetComponent<Image>();
        weaponImage.sprite = weaponSprites[index];
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (target != Vector3.zero)
        {
            image.rectTransform.localPosition = Vector2Extention.LerpCurve(originalPos, midpoint, target, speed);
            speed += 0.1f;
            if (image.rectTransform.localPosition == target)
            {
                target = Vector3.zero;
                image.rectTransform.localPosition = originalPos;
                speed = 0.1f;
                weaponImage.sprite = weaponSprites[index];
            }
        }
	}

    public void SetProperties(Vector3 _target, int _index)
    {
        target = _target;
        index = _index;
        if (is3rdSlot)
        {
            weaponImage.sprite = weaponSprites[index];
        }
        midpoint = new Vector2(image.rectTransform.localPosition.x + target.x, image.rectTransform.localPosition.y + target.y);
    }
}
