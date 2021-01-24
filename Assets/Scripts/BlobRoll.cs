using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobRoll : MonoBehaviour
{
    public GameObject blob;
    public GameObject sphere;
    private playerMovement PM;


    // Start is called before the first frame update
    void Start()
    {
       PM = FindObjectOfType<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.localScale -= new Vector3(1, 1, 1);
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.localScale += new Vector3(1, 1, 1);
        //}

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("rurka"))
        {
            PM.speed += 0.7f;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag.Equals("rurka"))
        {
            GetComponent<Rigidbody>().freezeRotation = false;
            PM.setIsSphere(true);

            foreach (Collider c in blob.GetComponents<Collider>())
            {
                c.enabled = false;
            }

            blob.active = false;
            sphere.active = true;
            foreach (Collider c in sphere.GetComponents<Collider>())
            {
                c.enabled = true;
            }
    

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag.Equals("rurka"))
        {
            PM.setIsSphere(false);
            PM.speed -= 0.7f;
            foreach (Collider c in sphere.GetComponents<Collider>())
            {
                c.enabled = false;
            }
            sphere.active = false;
            blob.active = true;
            foreach (Collider c in blob.GetComponents<CapsuleCollider>())
            {
                c.enabled = true;
            }
           
            GetComponent<Rigidbody>().freezeRotation = true;

        }
    }



}
