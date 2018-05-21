using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weap02Script : MonoBehaviour {

    /// <summary>
    /// The time in seconds it takes for the weapon to fully charge.
    /// </summary>
    public float chargeTime = 1.5f;

    public Texture2D cursorGreen;
    public Texture2D cursorRed;

    public GameObject bulletPrefab;

    private Animator animator;
    private float deltaTime;

    public LayerMask mask;

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

    void FixedUpdate()
    {
        if (!StaticVariables.controlLock)
        {
            if (Input.GetMouseButton(0) && GetComponent<WeaponScript>().energy != 0)
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
            if (rotZ >= -165 && rotZ <= -15)
            {
                Cursor.SetCursor(cursorGreen, new Vector2(24, 24), CursorMode.ForceSoftware);
            }
            else
            {
                Cursor.SetCursor(cursorRed, new Vector2(24, 24), CursorMode.ForceSoftware);
            }
        }
    }

    public void Raycast()
    {
        Camera theCamera = Camera.main;

        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(target);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target, Mathf.Infinity, mask);
        if (hit.collider != null)
        {
            Debug.Log("We hit " + hit.collider.gameObject.name + hit.point);
        }
        Debug.DrawRay(transform.position, hit.point, Color.green, 5);
    }

    void Fire()
    {
        if (GetComponent<WeaponScript>().energy != 0)
        {
            float rotZ = GetMouseRotation();
            Quaternion newRotation;
            if (rotZ >= -165 && rotZ <= -15)
            {
             //   Raycast();
                newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ));
                Instantiate(bulletPrefab, transform.position, newRotation);

                if (GetComponent<AudioSource>() != null)
                {
                    GetComponent<AudioSource>().Play();
                }
                transform.parent.SendMessage("SubtractEnergy");
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
}
