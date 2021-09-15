using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button _button;
    private List<System.Action> _actions = new List<System.Action>();
    private int _clicks;
    public int buttonIndex;

    
    public event Action<int> Clicked;
    private void Start()
    {
        _button.onClick.AddListener(OnCLick);
        _actions.Add(ColourToBLue);
        _actions.Add(colourToRed);
    }

    public void Initialize(int index)
    {
        buttonIndex = index;
        
    }
    public void ColourToBLue()
    {
        if (_button.interactable)
        {
            _button.image.color = Color.blue;
        }
    }

    public void colourToRed()
    {
        if (_button.interactable)
        {
            _button.image.color = Color.yellow;
            _button.interactable = false;
        }
    }

    public void OnCLick()
    {
        if (Clicked != null)
        {
            Clicked(buttonIndex);
        }
        _actions[_clicks].Invoke();
        _clicks = (_clicks + 1) % _actions.Count;
    }


}
