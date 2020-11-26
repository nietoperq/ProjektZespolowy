using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onHoverChangeText2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text myText;


    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.text = "- Quit -";
        myText.fontSize = 58;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.text = "Quit";
        myText.fontSize = 52;
    }
}
