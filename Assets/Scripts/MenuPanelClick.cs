using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPanelClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Panel đã được bấm!");
        GameManager.Instance.StartGame();
    }
}
