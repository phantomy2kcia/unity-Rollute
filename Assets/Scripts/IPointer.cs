using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class IPointer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
    public int speed;
    public int Check;
    public Slider slider;
    public bool change = false;
    public bool button_check=false;
    public bool first = false;
    public static IPointer instance;
    void Start()
    {
        instance = this;
        slider.minValue = 0;
        slider.maxValue = 200;       
    }
    public void Update()
    {
        Onclick();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        button_check = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        button_check = false;
    }
    public void Onclick()
    {
        if (!Rotate.instance.on_rotate)
        {
            if (button_check)
            {
                if (!first)
                    slider.value = 0;

                if (slider.value.Equals(slider.maxValue))
                    change = true;
                else if (slider.value.Equals(slider.minValue))
                    change = false;

                if (change)
                    slider.value -= 2;
                else
                    slider.value += 2;
                first = true;
            }
        }
        else if (first)
        {
            Check = (int)slider.value / 40;
            switch (Check)
            {
                case 0:
                    speed = 100;
                    break;
                case 1:
                    speed = 150;
                    break;
                case 2:
                    speed = 200;
                    break;
                case 3:
                    speed = 250;
                    break;
                case 4:
                    speed = 300;
                    break;
                case 5:
                    speed = 350;
                    break;
                default:
                    speed = 0;
                    break;
            }
            slider.value = 0;
            Rotate.instance.rotspeed = speed;
            first = false;
        }
    }
}