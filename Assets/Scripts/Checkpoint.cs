using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public HealthManager theHM;

    public Renderer theRend;

    private GameObject particle;
    public ParticleSystem checkpointEffect;

    void Start()
    {
        checkpointEffect.Stop();
    }

    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Saving");
                // theHM.SetSpawnPoint(other.transform.position);

                Vector3 playerPos = other.transform.position;
                PlayerPrefs.SetFloat("PlayerPosX", playerPos.x);
                PlayerPrefs.SetFloat("PlayerPosY", playerPos.y);
                PlayerPrefs.SetFloat("PlayerPosZ", playerPos.z);

                // Vector3 newPos = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);

                Vector3 newPos = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));

                //  theHM.SetSpawnPoint(newPos);

                StartCoroutine("EffectCo");

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
                    PlayerPrefs.SetString("isSaved", "true");
                }
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


    public IEnumerator EffectCo()
    {
        checkpointEffect.Play();
        yield return new WaitForSeconds(2);
        checkpointEffect.Stop();

    }


}
