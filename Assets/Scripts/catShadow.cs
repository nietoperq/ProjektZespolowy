using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catShadow : MonoBehaviour
{

    public Light light;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("Actions");
        StartCoroutine("Walk");
    }

    IEnumerator Actions()
    {
        while (true)
        {
        Blink();
        yield return new WaitForSeconds(1f);
        Blink();
        yield return new WaitForSeconds(0.7f);
        Blink();
        yield return new WaitForSeconds(0.2f);
        Blink();
        yield return new WaitForSeconds(2f);
        Blink();
        yield return new WaitForSeconds(1f);

        if (!enabled) break;
        }

    }
    
    IEnumerator Walk()
    {
        Vector3 newPos = transform.position + new Vector3(-76f, 0, 0);
        Vector3 startPos = transform.position;
        float timeToDoIt = 15f;
        float t = 0f;
        while (t < timeToDoIt)
        {
            transform.position = Vector3.Lerp(startPos, newPos, (t / timeToDoIt));
            t += Time.deltaTime;

            yield return null;
        }

    }


    public void Blink()
    {
        light.enabled = !light.enabled;

    }
}

