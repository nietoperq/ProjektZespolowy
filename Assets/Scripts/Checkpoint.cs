using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public HealthManager theHM;

    public ParticleSystem checkpointEffect;
    public Light lightEffect;

    void Start()
    {
        checkpointEffect.Stop();
        if (PlayerPrefs.GetInt(this.transform.parent.name + "saved") != 1)
            lightEffect.enabled = false;
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
                PlayerPrefs.SetInt(this.transform.parent.name + "saved", 1);
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

                    PlayerPrefs.SetString("isSaved", "true");
                    PlayerPrefs.Save();

                }
            }
        }
    }

    public void ReloadScene()
    {
        Cursor.visible = false;

        string[] tagsForCheckpoint =
          {
                 "Player",
                 "MovableObject",
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

        object[] checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        foreach (object c in checkpoints)
        {
            GameObject g = (GameObject)c;
            string gName = g.name;
            if (PlayerPrefs.GetInt(gName + "saved") == 1)
            {
                Light l = g.GetComponentInChildren<Light>();
                Debug.Log("reload" + gName);
                l.enabled = true;
            }
        }

    }


    public IEnumerator EffectCo()
    {
        lightEffect.enabled = true;
        PlayerPrefs.SetInt(lightEffect.name, 1);
        checkpointEffect.Play();
        yield return new WaitForSeconds(2);
        checkpointEffect.Stop();

    }


}
