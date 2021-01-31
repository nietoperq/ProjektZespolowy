using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBlink : MonoBehaviour
{
    public Light catLight;
    public Material catEye;
    public Material catClosed;
    public MeshRenderer meshRenderer;
    public Light halo;
    public bool catBlinked;
    public GameObject catEyeVis;

    void OnEnable()
    {
        StartCoroutine("Actions");
    }

    IEnumerator Actions()
    {
        while ( true )
        {
            Blink();
            yield return new WaitForSeconds(3);
            Blink();
            yield return new WaitForSeconds(0.7f);
            Blink();
            yield return new WaitForSeconds(0.7f);
            Blink();
            yield return new WaitForSeconds(3);

            if (!this.GetComponent<CatBlink>().enabled) break;
        }

    }

    public void Blink()
    {
        if (!catBlinked)
        {
            this.GetComponent<catSight>().enabled = false;
            catLight.enabled = false;
            catEyeVis.GetComponent<MeshRenderer>().material = catClosed;
            halo.enabled = false;
        }

        else
        {
            this.GetComponent<catSight>().enabled = true;
            catLight.enabled = true;
            catEyeVis.GetComponent <MeshRenderer>().material = catEye;
            halo.enabled = true;
        }

        catBlinked = !catBlinked;
    }
}
