using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public HealthManager theHM;

    public Renderer theRend;

    public Material checkpOff;
    public Material checkpOn;



    void Start()
    {

    }

    void Update()
    {

    }

    public void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();

        foreach (Checkpoint cp in checkpoints)
        {
            cp.theRend.material = checkpOff;
        }

        theRend.material = checkpOn;
    }

    public void CheckpointOff()
    {
        theRend.material = checkpOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            // theHM.SetSpawnPoint(other.transform.position);

            Vector3 playerPos = other.transform.position;
            PlayerPrefs.SetFloat("PlayerPosX", playerPos.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerPos.y);
            PlayerPrefs.SetFloat("PlayerPosZ", playerPos.z);

            // Vector3 newPos = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);

            Vector3 newPos = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));

            //  theHM.SetSpawnPoint(newPos);

            CheckpointOn();

            string[] tagsForCheckpoint =
            {
                 "Player",
                 "MovableObject"
             };
            foreach (string tag in tagsForCheckpoint)
            {
                object[] obj = GameObject.FindGameObjectsWithTag(tag);
                foreach (object o in obj)
                {

                    GameObject g = (GameObject)o;

                    string gName = g.name;

                    PlayerPrefs.SetFloat(gName + "PosX", g.transform.position.x);
                    PlayerPrefs.SetFloat(gName + "PosY", g.transform.position.y);
                    PlayerPrefs.SetFloat(gName + "PosZ", g.transform.position.z);
                    PlayerPrefs.SetFloat(gName + "RotX", g.transform.eulerAngles.x);
                    PlayerPrefs.SetFloat(gName + "RotY", g.transform.eulerAngles.y);
                    PlayerPrefs.SetFloat(gName + "RotZ", g.transform.eulerAngles.z);

                }

                PlayerPrefs.Save();
            }
        }
    }

    public void ReloadScene()
    {
        string[] tagsForCheckpoint =
          {
                 "Player",
                 "MovableObject"
           };

        foreach (string tag in tagsForCheckpoint)
        {
            object[] obj = GameObject.FindGameObjectsWithTag(tag);
            foreach (object o in obj)
            {
                GameObject g = (GameObject)o;
                string gName = g.name;

                Rigidbody rb = g.GetComponent<Rigidbody>();


                Vector3 pos = new Vector3(PlayerPrefs.GetFloat(gName + "PosX"), PlayerPrefs.GetFloat(gName + "PosY"), PlayerPrefs.GetFloat(gName + "PosZ"));
                Vector3 rot = new Vector3(PlayerPrefs.GetFloat(gName + "RotX"), PlayerPrefs.GetFloat(gName + "RotY"), PlayerPrefs.GetFloat(gName + "RotZ"));
                g.transform.position = pos;
                g.transform.eulerAngles = rot;

                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
        }
    }
}
