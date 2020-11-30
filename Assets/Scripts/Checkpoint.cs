using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public HealthManager theHM;

    public Renderer theRend;

    public Material checkpOff;
    public Material checkpOn;



    // Start is called before the first frame update
    void Start()
    {
        theHM = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();

        foreach(Checkpoint cp in checkpoints)
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
        if(other.tag.Equals("Player"))
        {
            theHM.SetSpawnPoint(other.transform.position);
            CheckpointOn();
        }
    }
}
