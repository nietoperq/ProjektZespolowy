﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class cageButton : MonoBehaviour
{
    public GameObject button;

    public GameObject[] miceEyes;
    public GameObject[] cageBars;
    private Vector3[] newBarPos = new Vector3[3];

    private bool buttonPressed = false;
    private bool cageOpened = false;
    private bool dontUpdate = false;

    float t = 0;
    public float timeToDoIt;

    public Camera camera;

    private Vector3 oldCameraPos;
    private Vector3 newCameraPos;


    public VideoPlayer ratEscape;

    public GameObject mouse;


    void Start()
    {

        miceEyes = GameObject.FindGameObjectsWithTag("MouseEyes");
        cageBars = GameObject.FindGameObjectsWithTag("cageBar");

        int j = 0;
        foreach (GameObject i in cageBars)
        {
            Vector3 temp = i.transform.position;
            newBarPos[j] = temp + new Vector3(0, 10f, 0);
            j++;
        }

        oldCameraPos = camera.transform.position;
        newCameraPos = oldCameraPos + new Vector3(30f, 0, 0);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "cageButton")
        {

            button.transform.position += new Vector3(0, -0.5f, 0);


            foreach (GameObject i in miceEyes)
            {
                i.GetComponent<Light>().enabled = false;
            }

            buttonPressed = true;

            playerMovement.isInputEnabled = false;
            camera.GetComponent<CameraController>().enabled = false;

        }
    }

    void Update()
    {
        if (buttonPressed && !cageOpened)
        {
            t += Time.deltaTime / timeToDoIt;

            camera.transform.position = Vector3.Lerp(oldCameraPos, newCameraPos, t);
            //camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 30f, t / 5);

            int k = 0;
            foreach (GameObject i in cageBars)
            {
                i.transform.position = Vector3.Lerp(i.transform.position, newBarPos[k], t/20);
                k++;
            }

            if (cageBars[0].transform.position == newBarPos[0] && camera.transform.position == newCameraPos && !dontUpdate)
            {
                cageOpened = true;
                StartCoroutine("Cutscene", ratEscape);
                dontUpdate = true;

            }
        }
    }

    public IEnumerator Cutscene(VideoPlayer vp)
    {
        ratEscape.enabled = true;
        yield return new WaitForSeconds(7.5f);
        ratEscape.enabled = false;


        playerMovement.isInputEnabled = true;
        camera.GetComponent<CameraController>().enabled = true;

        mouse.SetActive(true);

    }

}
