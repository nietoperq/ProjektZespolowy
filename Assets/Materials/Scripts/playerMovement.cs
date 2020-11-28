
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private Vector3 direction;

    public float knockbackTime;
    public float knockbackForce;
    public float knockbackCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        if (knockbackCounter <= 0)
        {
            HealthManager.isHurt = false;
            float xMov = Input.GetAxis("Horizontal");
            float zMov = Input.GetAxis("Vertical");

            direction = new Vector3(xMov * speed, rb.velocity.y, zMov * speed);

            rb.velocity = direction;
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
        }
    }

    public void Knockback(Vector3 knockbackDirection)
    {
        knockbackCounter = knockbackTime;
        direction = knockbackDirection * knockbackForce;
        rb.velocity = direction;

    }

}
