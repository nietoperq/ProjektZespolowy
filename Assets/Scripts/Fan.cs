using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private bool isFlying = false;
    private bool isFalling = false;

   private Vector3 flyingDirection;
    private Rigidbody rb;

    public float flyingSpeed = 0;
    private float defaultVelocity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        flyingDirection = new Vector3(rb.velocity.x, flyingSpeed, rb.velocity.z);
        defaultVelocity = rb.velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlying)
        {
            rb.velocity += flyingDirection;
        }
        else if(isFalling)
        {
            rb.velocity = new Vector3(rb.velocity.x, defaultVelocity, rb.velocity.z);
            isFalling = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "fan")
        {
            isFlying = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "fan")
        {
            isFlying = false;
            isFalling = true;
        }
    }

}
