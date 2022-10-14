using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShootArea : MonoBehaviour, IPointerDownHandler
{
    public UnityAction Click;

    public void OnPointerDown(PointerEventData eventData)
    {
        Click?.Invoke();
    }
}
