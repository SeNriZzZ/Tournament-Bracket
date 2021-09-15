using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnController : MonoBehaviour
{
    [SerializeField] private ButtonController _buttonPrefab;
    
    public event Action<int, int> OnClick;
    private int _columnIndex;
    private int _playerCount;
    
    private void Start()
    {
        Debug.Log(this.transform.parent.childCount);
    }

    public void Initialize(int count, int buttonsToCreate)
    {
        _columnIndex = buttonsToCreate;
        _playerCount = count;
        for (int i = 0; i < buttonsToCreate; i++)
        {
            BuildButtons(i);
        }
        
       
    }
    
    
    public void BuildButtons(int i)
    {
       ButtonController button = Instantiate(_buttonPrefab);
       button.transform.parent = this.transform;
       button.Initialize(i);
       button.Clicked+=OnButtonClicked;
    }

    private void OnButtonClicked(int buttonIndex)
    {
        if (OnClick != null)
        {
            OnClick(buttonIndex, _columnIndex);
        }
    }
}
