using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Vector2 joystickCenter; 
    private Vector2 inputVector;

    [SerializeField] private RectTransform stickTransform; 
    [SerializeField] private float joystickRadius = 50f;

    private void Start()
    {
        joystickCenter = stickTransform.anchoredPosition; 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - joystickCenter; 
        inputVector = direction.normalized;

        if (direction.magnitude > joystickRadius)
        {
            direction = direction.normalized * joystickRadius; 
        }

        stickTransform.anchoredPosition = joystickCenter + direction; 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stickTransform.anchoredPosition = Vector2.zero;
        inputVector = Vector2.zero;
    }

    public float Horizontal()
    {
        return inputVector.x;
    }

    public float Vertical()
    {
        return inputVector.y;
    }
}