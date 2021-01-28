using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class MouseAI : MonoBehaviour
{
    private int i = 0;
    private Vector3[] positions = new Vector3[5];
    private Vector3 newPos;

    public Camera camera;
    private bool inMovement = false;
    public GameObject ksiazka;
    private Rigidbody bookRb;

    float t = 0f;
    private float timeToDoIt;

    public VideoPlayer ratIsDead;
    public GameObject player;

    void Start()
    {
        positions[0] = new Vector3(-54f, 0, 0);
        positions[1] = new Vector3(0, 0, 20f);
        positions[2] = new Vector3(-7f, 0, 0);
        positions[3] = new Vector3(-86f, 0, 0);
        positions[4] = new Vector3(0, 0, 20f);


        // GetComponent<Rigidbody>().detectCollisions = false;
        GetComponent<Rigidbody>().isKinematic = true;
        bookRb = ksiazka.GetComponent<Rigidbody>();
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
        if(!inMovement)
        {
            inMovement = true;



            switch (i)
            {
                case 0:
                    newPos = transform.position + positions[i];
                    timeToDoIt = 3f;
                    t = 0f;
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt) * 0.2f);

                        yield return null;
                    }


                    i = 1;
                    break;


                case 1:
                    newPos = transform.position + positions[i];
                    timeToDoIt = 2f;
                    //do dziury
                    t = 0f;
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt) * 0.2f);

                        yield return null;
                    }

                    transform.position = new Vector3(-93f, 24f, 7f);//teleportacja

                    //manipulacja kamerom
                    timeToDoIt = 3;
                    camera.GetComponent<CameraController>().enabled = false;

                    Vector3 oldCameraPos = camera.transform.position;
                    Vector3 newCameraPos = camera.transform.position + new Vector3(0, 0, -50f);
                    t = 0;
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        camera.transform.position = Vector3.Lerp(oldCameraPos, newCameraPos, (t / timeToDoIt) * 0.2f);
                    }

                    timeToDoIt = 1f;
                    newPos = transform.position + new Vector3(0, 0, -10f);
                    //wyjscie z dziury
                    t = 0f;
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt) * 0.2f);

                        yield return null;
                    }

                    switchRigid();

                    timeToDoIt = 2f;
                    newPos = transform.position += new Vector3(4f, 0, 0);
                    //pchniecie ksiazki
                    t = 0f;
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt) * 0.02f);

                        yield return null;
                    }

                    yield return new WaitForSeconds(2);

                    bookRb.mass = 100f;

                    switchRigid();

                    newPos = new Vector3(-93f, 24f, 7f);
                    //powrot do dziury
                    t = 0f;
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt) * 0.2f);

                        yield return null;
                    }


                    camera.GetComponent<CameraController>().enabled = true;

                    transform.position += new Vector3(0, -22f, 0);//teleportacja

                    newPos = transform.position + new Vector3(0, 0, -14f);
                    t = 0f;
                    //wyjscie z dziury 2
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt) * 0.2f);

                        yield return null;
                    }

                    i = 2;

                    break;

                case 2:
                    timeToDoIt = 0.5f;
                    //spaście z pólki
                    newPos = transform.position + positions[i];
                    t = 0f;
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt));

                        yield return null;
                    }
                    switchRigid();
                    yield return new WaitForSeconds(1f);
                    switchRigid();

                    i = 3;
                    break;

                case 3:
                    //wziuum dalejko na poczatek
                    newPos = transform.position + positions[i];
                    timeToDoIt = 4f;
                    t = 0f;
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt) * 0.03f);

                        yield return null;
                    }
                    i = 4;
                    break;

                case 4:

                    newPos = transform.position + positions[i];
                    timeToDoIt = 2f;
                    //do dziury
                    t = 0f;
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt) * 0.2f);

                        yield return null;
                    }

                    transform.position += new Vector3(-5f, 10f, 0);//teleportacja

                    newPos = transform.position + new Vector3(0, 0, -14f);
                    t = 0f;
                    //wyjscie z dziury 2
                    while (t < timeToDoIt)
                    {
                        t += Time.deltaTime;
                        transform.position = Vector3.Lerp(transform.position, newPos, (t / timeToDoIt) * 0.2f);

                        yield return null;
                    }

                    yield return new WaitForSeconds(2f);
                    newPos = player.transform.position;
                    ratIsDead.enabled = true;
                    yield return new WaitForSeconds(22f);



                    ratIsDead.enabled = false;
                    player.transform.position = newPos;

                    break;

            }


            inMovement = false;

        }      

        
        yield return null;
    }

    private void switchRigid()
    {
        GetComponent<Rigidbody>().isKinematic = !GetComponent<Rigidbody>().isKinematic;
    }

}