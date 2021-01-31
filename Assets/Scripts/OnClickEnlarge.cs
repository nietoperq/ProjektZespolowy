using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEnlarge : MonoBehaviour
{
    private GameObject image;
    private Sprite concept;


    // Start is called before the first frame update
    void SwapImage()
    {    
        image = GameObject.FindGameObjectWithTag("image");
        concept = GetComponent<Image>().sprite;
        image.GetComponent<Image>().sprite = concept;
    }

}
