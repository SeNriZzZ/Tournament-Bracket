using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnController : MonoBehaviour
{
    [SerializeField] private ButtonController _buttonPrefab;

    private ButtonController[] buttonsArray;
    public event Action<int, int> OnClick;
    private int _columnIndex;
    
    
    private void Start()
    {
        Debug.Log(this.transform.parent.childCount);
    }

    public void Initialize(int buttonsToCreate, int columnIndex)
    {
        _columnIndex = columnIndex;
        
        buttonsArray = new ButtonController[buttonsToCreate];
        for (int i = 0; i < buttonsToCreate; i++)
        {
            buttonsArray[i]= BuildButtons(i);
        }
        
       
    }
    
    
    public ButtonController BuildButtons(int i)
    {
       ButtonController button = Instantiate(_buttonPrefab);
       button.transform.parent = this.transform;
       button.Initialize(i);
       button.Clicked+=OnButtonClicked;
       return button;
    }

    private void OnButtonClicked(int buttonIndex)
    {
        if (OnClick != null)
        {
            OnClick(buttonIndex, _columnIndex);
        }
        
    }
}
