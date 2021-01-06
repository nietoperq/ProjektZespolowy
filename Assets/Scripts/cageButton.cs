using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cageButton : MonoBehaviour
{
    public GameObject button;

    public GameObject[] miceEyes;
    public GameObject[] cageBars;
    private Vector3[] newBarPos = new Vector3[3];

    private bool buttonPressed = false;
    private bool cageOpened = false;

    float t = 0;
    public float timeToDoIt;

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
        }
    }

    void Update()
    {
        if(buttonPressed)
        {
            t += Time.deltaTime / timeToDoIt;

            int k = 0;
            foreach (GameObject i in cageBars)
            {
                i.transform.position = Vector3.Lerp(i.transform.position, newBarPos[k], t);
                k++;
            }
        }
    }
}
