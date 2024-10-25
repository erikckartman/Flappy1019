using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image joystickBackground;
    [SerializeField] private Image joystickHandle;
    private Vector2 inputVector;


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out position))
        {
            // Нормалізуємо координати
            position.x = (position.x / joystickBackground.rectTransform.sizeDelta.x);
            position.y = (position.y / joystickBackground.rectTransform.sizeDelta.y);

            inputVector = new Vector2(position.x * 2, position.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // Переміщуємо рукоятку джойстика
            joystickHandle.rectTransform.anchoredPosition = new Vector2(
                inputVector.x * (joystickBackground.rectTransform.sizeDelta.x / 2),
                inputVector.y * (joystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickHandle.rectTransform.anchoredPosition = Vector2.zero;
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