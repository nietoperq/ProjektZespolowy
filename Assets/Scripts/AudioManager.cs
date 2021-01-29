using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip musicBegins;
    public AudioClip musicLooped;
    void Start()
    {
        GetComponent<AudioSource>().loop = true;
        StartCoroutine(playMusic());
    }

    IEnumerator playMusic()
    {
        GetComponent<AudioSource>().clip = musicBegins;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        GetComponent<AudioSource>().clip = musicLooped;
        GetComponent<AudioSource>().Play();
    }
}
