using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;


    private Vector3 direction;

    public float knockbackTime;
    public float knockbackForce;
    public float knockbackCounter;

    public static bool isInputEnabled = true;
    private bool isSphere = false;

    public bool isMouse;

    private float zMovementMultiplier = 1f;

    Vector3 rot;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        if (isMouse)
            zMovementMultiplier = 3f;

    }

    void FixedUpdate()
    {


        if (knockbackCounter <= 0 && isInputEnabled)
        {
            HealthManager.isHurt = false;
            float xMov = Input.GetAxis("Horizontal");
            float zMov = Input.GetAxis("Vertical");

            direction = new Vector3(xMov * speed, rb.velocity.y, zMov * zMovementMultiplier * speed);

            rb.velocity = direction;
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
        }


        rot = new Vector3(0, transform.eulerAngles.x, 0);
        if (!isSphere && !isMouse)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rot.y = 90;
                transform.eulerAngles = rot;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rot.y = 180;
                transform.eulerAngles = rot;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rot.y = -90;
                transform.eulerAngles = rot;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rot.y = 0;
                transform.eulerAngles = rot;
            }
        }
        if(isMouse)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rot.y = 0;
                transform.eulerAngles = rot;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rot.y = -90;
                transform.eulerAngles = rot;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rot.y = 180;
                transform.eulerAngles = rot;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rot.y = 90;
                transform.eulerAngles = rot;
            }
        }
       
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

        if (rb.velocity.y <= -1)
        {
            anim.SetBool("falling", true);
        }
        else
        {
            anim.SetBool("falling", false);
        }
    }

    public void Knockback(Vector3 knockbackDirection)
    {
        knockbackCounter = knockbackTime;
        direction = knockbackDirection * knockbackForce;
        rb.velocity = direction;
    }

    public void Flying(float flyingSpeed)
    {
        direction = new Vector3(rb.velocity.x, flyingSpeed, rb.velocity.z);
    }

    public void setIsSphere(bool b)
    {
        isSphere = b;
    }

}
