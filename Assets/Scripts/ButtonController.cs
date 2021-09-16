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
    public int columnIndex;

    
    public event Action<int, int> Clicked;
    private void Start()
    {
        _button.onClick.AddListener(OnCLick);
        _actions.Add(ColourToBLue);
        _actions.Add(ColourToYellow);
    }

    public void Initialize(int index, int ColumnIndex)
    {
        buttonIndex = index;
        columnIndex = ColumnIndex;
    }
    public void ColourToBLue()
    {
        if (_button.interactable)
        {
            _button.image.color = Color.blue;
        }
    }

    public void ColourToYellow()
    
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
            Clicked(buttonIndex, columnIndex);
            _actions[_clicks].Invoke();
            _clicks = (_clicks + 1) % _actions.Count;
        }
        
    }


    public void SetBlack()
    {
        _button.image.color = Color.black;
        _button.interactable = false;
    }

    public bool IsBlue()
    {
        return _button.image.color == Color.blue;
    }

    public void SetBlue()
    {
        _button.image.color = Color.blue;
    }

    public void SetYellow()
    {
        _button.image.color = Color.yellow;
        _button.interactable = false;
    }

 
}
