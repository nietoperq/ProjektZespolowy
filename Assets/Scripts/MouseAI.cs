using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAI : MonoBehaviour
{
    private int i = 0;
    private Vector3[] positions = new Vector3[3];
    private Vector3 newPos;

    public Camera camera;

    float t = 0f;
    private float timeToDoIt;

    void Start()
    {
        positions[0] = new Vector3(-57f, 0, 0);
        positions[1] = new Vector3(0, 0, 20f);


       // GetComponent<Rigidbody>().detectCollisions = false;
        GetComponent<Rigidbody>().isKinematic = true;
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

        newPos = transform.position + positions[i];

        t = 0f;

        switch (i)
        {
            case 0:
                timeToDoIt = 3;

                while (t < timeToDoIt )
                {
                    t += Time.deltaTime ;
                    transform.position = Vector3.Lerp(transform.position, newPos, (t/timeToDoIt)*0.03f );

                    yield return null;
                }
                break;

            case 1:
                timeToDoIt = 2;
                //do dziury
                while (t < timeToDoIt)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(transform.position, newPos, (t/timeToDoIt)*0.2f );

                    yield return null;
                }

                transform.position = new Vector3(-93f, 24f, 7f);//teleportacja

                //manipulacja kamerom
                timeToDoIt = 3;
                t = 0;
                camera.GetComponent<CameraController>().enabled = false;
                
                Vector3 oldCameraPos  = camera.transform.position;
                Vector3 newCameraPos = camera.transform.position + new Vector3(0, 0, -50f);
                while (t < timeToDoIt)
                {
                    t += Time.deltaTime;
                    camera.transform.position = Vector3.Lerp(oldCameraPos, newCameraPos, t / timeToDoIt);
                }

                timeToDoIt = 1f;
                t = 0f;
                newPos = transform.position + new Vector3(0, 0, -10f);
                //wyjscie z dziury
                while (t < timeToDoIt)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt));

                    yield return null;
                }

                switchRigid();

                t = 0f;
                newPos = transform.position += new Vector3(3f, 0, 0);
                //pchniecie ksiazki
                while (t < timeToDoIt)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt));

                    yield return null;
                }

                yield return new WaitForSeconds(2);

                switchRigid();
                
                t = 0f;
                newPos = new Vector3(-93f, 24f, 7f);
                //powrot do dziury
                while (t < timeToDoIt)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt));

                    yield return null;
                }


                camera.GetComponent<CameraController>().enabled = true;

                transform.position += new Vector3(0, -20f, 0);//teleportacja

                newPos = transform.position + new Vector3(0, 0, -14f);
                t = 0f;
                //wyjscie z dziury 2
                while (t < timeToDoIt)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt));

                    yield return null;
                }


                break;
        }

        i++;
        
        yield return null;
    }

    private void switchRigid()
    {
        //GetComponent<Rigidbody>().detectCollisions = !GetComponent<Rigidbody>().detectCollisions;
        GetComponent<Rigidbody>().isKinematic = !GetComponent<Rigidbody>().isKinematic;
    }

}