﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class catSight : MonoBehaviour
{
    public SphereCollider col;
    public GameObject player;

    public VideoPlayer catDeath;
    public Light light;
    private Color defLightColor;

    void Start()
    {
        defLightColor = light.color;
    }


    void OnTriggerStay(Collider other)
    {

        if (other.gameObject == player)
        {
            Vector3 direction = other.transform.position - transform.position;

            RaycastHit hit;


            if (Physics.Raycast(transform.position, direction, out hit, col.radius))
            {
                if (hit.collider.gameObject == player && !this.GetComponent<CatBlink>().catBlinked)
                {
                    Debug.Log("Caught!");
                    StartCoroutine("RespawnCo", catDeath);

                }
                else
                {
              //      Debug.Log("Safe.");
                }
            }

        }

    }

    void OnTriggerExit(Collider other)
    {

    }


    public IEnumerator RespawnCo(VideoPlayer vp)
    {
        light.color = Color.cyan;
        playerMovement.isInputEnabled = false;
        Fade.fadeIn();
        yield return new WaitForSeconds(2);
        catDeath.enabled = true;

        yield return new WaitForSeconds(1);
        Vector3 respawnPoint = FindObjectOfType<HealthManager>().GetSpawnPoint();
        player.transform.position = respawnPoint;

        playerMovement.isInputEnabled = true;
        Fade.fadeOut();
        light.color = defLightColor;

    }

}
