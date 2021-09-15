using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnController : MonoBehaviour
{
    [SerializeField] private ButtonController _buttonPrefab;

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
            BuildButtons();
        }
        
       
    }

    public void BuildButtons()
    {
       ButtonController childObject = Instantiate(_buttonPrefab);
       childObject.transform.parent = this.transform;
       
    }
}
