using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class catSight : MonoBehaviour
{
    public SphereCollider col;
    public GameObject player;

    public VideoPlayer catDeath;


    void OnTriggerStay(Collider other)
    {

        if(other.gameObject == player)
        {
            Vector3 direction = other.transform.position - transform.position;

            RaycastHit hit;


            if (Physics.Raycast(transform.position, direction, out hit, col.radius))
            {
                if (hit.collider.gameObject == player && !this.GetComponent<CatBlink>().catBlinked )
                {
                    Debug.Log("Caught!");              
                    catDeath.enabled = true;
                    player.GetComponent<playerMovement>().enabled = false;

                }
                else
                {             
                    Debug.Log("Safe.");
                }
            }
            
        }

    }

    void OnTriggerExit(Collider other)
    {

    }

}
