using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public GameObject player;

    //public LayerMask targetMask;
    //public LayerMask obstacleMask;

    bool playerSpotted;

    void start()
    {
        Debug.Log("I'm here! In fov!");
        playerSpotted = false;
    }

    void Update()
    {
        FindVisibleTargets();
    }

    void FindVisibleTargets()
    {
        Vector3 direction = player.transform.position - transform.position;

        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < viewRadius * 0.5f)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, direction.normalized, out hit, viewRadius))
            {
                if (hit.collider.gameObject == player)
                {
                    playerSpotted = true;
                    //meshRenderer.material = catEyeSighted;
                    UnityEngine.Debug.Log("I'm here!");

                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }


}
