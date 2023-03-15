using UnityEngine;
using UnityEngine.UI;

public class FiguresSelectorButtons : MonoBehaviour

{
    [SerializeField] Button _button;
    [SerializeField] private Sprite _buttonOn;

    private Sprite _buttonOff;
    private bool _isOff = true;

    private void Start()
    {
        _buttonOff = _button.image.sprite;
    }

    public void ButtonSwitch()
    {
        if (_isOff)
        {
            _button.image.sprite = _buttonOn;
            _isOff = false;
        }
        else
        {
            _button.image.sprite = _buttonOff;
            _isOff = true;
        }
    }
}
