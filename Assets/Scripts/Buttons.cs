using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour

{
    [SerializeField] Button button;
    [SerializeField] private Sprite buttonOn;
    private Sprite buttonOff;
    private bool isOff = true;

    private void Start()
    {
        buttonOff = button.image.sprite;
    }

    public void ButtonSwitch()
    {
        if (isOff)
        {
            button.image.sprite = buttonOn;
            isOff = false;
        }

        else
        {
            button.image.sprite = buttonOff;
            isOff = true;
        }
    }
}
