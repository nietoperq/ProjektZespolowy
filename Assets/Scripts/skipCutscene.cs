using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class skipCutscene : MonoBehaviour
{
    public GameObject postp;
    private void Start()
    {
        postp = GameObject.Find("PostProcessingManager");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.GetComponent<VideoPlayer>().enabled )
        {
            this.GetComponent<VideoPlayer>().enabled = false;
            postp.SetActive(true);
        }
    }
}