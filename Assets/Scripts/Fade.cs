using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image imgBlackScreen; 
    public static Image blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen = imgBlackScreen;
        imgBlackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
   public static void fadeIn()
    {
        blackScreen.CrossFadeAlpha(1, 2, false);
    }

    public static void fadeOut()
    {
        blackScreen.CrossFadeAlpha(0, 2, false);
    }
}
