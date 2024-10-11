using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPointerDown = false;
    public UnityEvent eventListener;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }

    private void Update()
    {
        if (isPointerDown)
        {
            eventListener.Invoke();
        }
    }
}
