using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour
{

    private ParticleSystem pSteam;

    private HurtPlayer HP;

    private Vector3 knockbackDirection;

    // Start is called before the first frame update
    void Start()
    {
        pSteam = GetComponent<ParticleSystem>();
        StartCoroutine("SteamCo");
        HP = FindObjectOfType<HurtPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            knockbackDirection = other.transform.position - transform.position;
            knockbackDirection = knockbackDirection.normalized;

            StartCoroutine("DamageCo");

            Debug.Log("Particle collision");
          
        }
    }


    public IEnumerator SteamCo()
    {
        while(true)
        {
            pSteam.Play();
            yield return new WaitForSeconds(4);
            pSteam.Stop();
            yield return new WaitForSeconds(3);
        }
    }

    public IEnumerator DamageCo()
    {
        FindObjectOfType<HealthManager>().HurtPlayer(1, knockbackDirection);
        yield return new WaitForSeconds(2);

    }
}
