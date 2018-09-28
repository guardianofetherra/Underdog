using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler{

    private Image BackgroundImg;
    private Image JoystickImg;
    private Vector3 InputVector;

    public void Start()
    {
        BackgroundImg = GetComponent<Image>();
        JoystickImg = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerUp(PointerEventData ped)
    {
        InputVector = Vector3.zero;
        JoystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }
    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public void OnDrag(PointerEventData ped)
    {
        Vector2 Pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BackgroundImg.rectTransform, ped.position, ped.pressEventCamera, out Pos))
        {
            Pos.x = (Pos.x/BackgroundImg.rectTransform.sizeDelta.x);
            Pos.y = (Pos.y/BackgroundImg.rectTransform.sizeDelta.y);

            InputVector = new Vector3(Pos.x * 2 + 1, Pos.y * 2 - 1, 0);
            InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;

            JoystickImg.rectTransform.anchoredPosition = new Vector3(InputVector.x * (BackgroundImg.rectTransform.sizeDelta.x / 2), (InputVector.y * BackgroundImg.rectTransform.sizeDelta.y / 2));

            //Debug.Log(InputVector);
        }
    }

    public float Horizontal()
    {
        if(InputVector.x != 0)
        {
            return InputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float Vertical()
    {
        if (InputVector.y != 0)
        {
            return InputVector.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
