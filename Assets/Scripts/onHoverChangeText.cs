using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onHoverChangeText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Text myText;

    private string enter;
    private string exit;

    void Start()
    {
        enter = "- " + myText.text + " -";
        exit = myText.text;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.text = enter;
        myText.fontSize = 58;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.text = exit;
        myText.fontSize = 52;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        myText.text = exit;
        myText.fontSize = 52;
    }

}