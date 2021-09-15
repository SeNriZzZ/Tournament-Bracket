using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button _button;
    private void Start()
    {
        _button.interactable = true;
    }

    public void OnButtonCLicked()
    {
        _button.image.color = Color.blue;
        if (_button.image.color == Color.blue)
        {
            _button.image.color = Color.red;
        }
        
    }
}
