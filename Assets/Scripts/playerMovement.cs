
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed ;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {

        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");

       Vector3 direction = new Vector3(xMov * speed, rb.velocity.y, zMov * speed);
        
        rb.velocity = direction;
    }


}
