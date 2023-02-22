using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiguresManager : MonoBehaviour

{
    [SerializeField] private Sprite buttonOff;
    private Sprite buttonOn;
    [SerializeField] Button button;
    private bool isOn = true;




    // Start is called before the first frame update
    void Start()
    {
        buttonOn = button.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonSwitch()
    {
        if (isOn)
        {
            button.image.sprite = buttonOff;
            isOn = false;
        }

        else
        {
            button.image.sprite = buttonOn;
            isOn = true;
        }
    }
}
