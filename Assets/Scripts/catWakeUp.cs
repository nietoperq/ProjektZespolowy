using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catWakeUp : MonoBehaviour
{
    GameObject gameObject;

    void Start()
    {
        gameObject = GameObject.Find("catEye");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<CatBlink>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<CatBlink>().enabled = false;
        }
    }
}
