using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onHoverChangeText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text myText;


    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.text = "- Start -";
        myText.fontSize = 58;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.text = "Start";
        myText.fontSize = 52;
    }
}