using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weap02Script : MonoBehaviour {

    /// <summary>
    /// Determines the delay between firing.
    /// </summary>
    public float fireTime = 0.5f;
    /// <summary>
    /// The energy of the weapon.
    /// </summary>
    public float energy = 10.0f;
    /// <summary>
    /// The ammount of energy it costs to fire the weapon.
    /// </summary>
    public float energyCost = 1.0f;

    public float chargeTime = 1.5f;

    public Texture2D cursorGreen;
    public Texture2D cursorRed;

    public GameObject bulletPrefab;

    private Animator animator;
    private float deltaTime;

    private void OnEnable ()
    {
        animator = GetComponent<Animator>();
        Cursor.SetCursor(cursorGreen, new Vector2(24, 24), CursorMode.ForceSoftware);
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            deltaTime += Time.deltaTime;
            if (deltaTime >= chargeTime)
            {
                animator.Play("Weap02 Charge");
            }
            else
            {
                animator.Play("Weap02 Charge 1");
            }
        }
        else
        {
            if (deltaTime >= chargeTime)
            {
                Fire();
            }
            deltaTime = 0;
            animator.Play("Start");
        }
        float rotZ = GetMouseRotation();
        Debug.Log(rotZ);
        if (rotZ >= -165 && rotZ <= -15)
        {
            Cursor.SetCursor(cursorGreen, new Vector2(24, 24), CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(cursorRed, new Vector2(24, 24), CursorMode.ForceSoftware);
        }
    }

    void Fire()
    {
        if (energy != 0)
        {
            float rotZ = GetMouseRotation();
            Quaternion newRotation;
            if (rotZ >= -165 && rotZ <= -15)
            {
                newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ));
                Instantiate(bulletPrefab, transform.position, newRotation);

                if (GetComponent<AudioSource>() != null)
                {
                    GetComponent<AudioSource>().Play();
                }
                EnergySubtract();
            }
        }
    }

    public float GetMouseRotation()
    {
        Camera theCamera = Camera.main; 

        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = target - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotZ -= 90;
        return rotZ;
    }

    public void EnergySubtract()
    {
        if (energy < energyCost)
        {
            energy = 0;
        }
        else if (energyCost > 0)
        {
            energy -= energyCost;
        }
        Debug.Log(gameObject.name + ": energy is " + energy);
    }
}
