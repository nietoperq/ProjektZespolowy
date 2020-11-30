using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catSight : MonoBehaviour
{
    //public float fieldOfViewAngle = 180f;
    public bool playerInSight;
    public SphereCollider col;
    public GameObject player;

    public Material catEyeSighted;
    public Material catEye;
    public MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        catEyeSighted = Resources.Load<Material>("catEyeSighted");
        playerInSight = false;

    }



    void OnTriggerStay(Collider other)
    {

        if(other.gameObject == player)
        {
            Vector3 direction = other.transform.position - transform.position;

            RaycastHit hit;


            if (Physics.Raycast(transform.position, direction, out hit, col.radius))
            {
                if (hit.collider.gameObject == player)
                {
                   // playerInSight = true;
                    meshRenderer.material = catEyeSighted;
                    Debug.Log("Caught!");

                }
                else
                {             
                    meshRenderer.material = catEye;
                    Debug.Log("Safe.");
                }
            }
            
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            meshRenderer.material = catEye;
        }
    }

}
