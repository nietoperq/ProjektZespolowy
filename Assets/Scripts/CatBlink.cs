using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBlink : MonoBehaviour
{
    public Light catLight;
    public Material catEye;
    public Material catClosed;
    public MeshRenderer meshRenderer;
    public Behaviour halo;
    public bool catBlinked;

    void Start()
    {
        catBlinked = true;
        StartCoroutine("Actions");
    }

    IEnumerator Actions()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            Blink();
            yield return new WaitForSeconds(0.7f);
            Blink();
            yield return new WaitForSeconds(0.7f);
            Blink();
            yield return new WaitForSeconds(3);
            Blink();
        }
    }

    public void Blink()
    {
        if(!catBlinked)
        {
            this.GetComponent<catSight>().enabled = false;
            catLight.enabled = false;
            meshRenderer.material = catClosed;
            halo.enabled = false;
        }

        else
        {
            this.GetComponent<catSight>().enabled = true;
            catLight.enabled = true;
            meshRenderer.material = catEye;
            halo.enabled = true;
        }

        catBlinked = !catBlinked;
    }
}
