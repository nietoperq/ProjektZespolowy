using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAI : MonoBehaviour
{
    private int i = 0;
    private Vector3[] positions = new Vector3[3];
    private Vector3 newPos;

    float t = 0f;
    private float timeToDoIt;

    void Start()
    {
        positions[0] = new Vector3(-60f, 0, 0);
        positions[1] = new Vector3(0, 0, 20f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Movement");
        }
    }

    public IEnumerator Movement()
    {

        newPos = this.transform.position + positions[i];

        t = 0f;

        switch (i)
        {
            case 0:
                timeToDoIt = 3;

                while (t < timeToDoIt )
                {
                    t += Time.deltaTime ;
                    this.transform.position = Vector3.Lerp(this.transform.position, newPos, (t/timeToDoIt)*0.03f );

                    yield return null;
                }
                break;

            case 1:
                timeToDoIt = 1;

                while (t < timeToDoIt)
                {
                    t += Time.deltaTime;
                    this.transform.position = Vector3.Lerp(this.transform.position, newPos, (t/timeToDoIt)*0.2f );

                    yield return null;
                }
                break;
        }

        i++;
        
        yield return null;
    }

}