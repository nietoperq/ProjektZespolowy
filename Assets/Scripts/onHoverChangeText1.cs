using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onHoverChangeText1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text myText;


    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.text = "- About the game -";
        myText.fontSize = 58;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.text = "About the game";
        myText.fontSize = 52;
    }
}