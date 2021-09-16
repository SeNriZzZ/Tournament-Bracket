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
            buttonsArray[i]= BuildButtons(i, _columnIndex);
        }
        
       
    }
    
    
    public ButtonController BuildButtons(int i, int columnIndex)
    {
       ButtonController button = Instantiate(_buttonPrefab);
       button.transform.parent = this.transform;
       button.Initialize(i, columnIndex);
       button.Clicked+=OnButtonClicked;
       return button;
    }

    public int GetButtonsCount()
    {
        var buttonsC = buttonsArray.Length;
        return buttonsC;
    }
    private void OnButtonClicked(int buttonIndex, int columnIndex)
    {
        if (OnClick != null)
        {
            OnClick(buttonIndex, _columnIndex);
        }
        
    }

    public void ChangeToBlack(int buttonIndex)
    {
        buttonsArray[buttonIndex].SetBlack();
    }

    public bool IsBlue(int buttonIndex)
    {
        return 
        buttonsArray[buttonIndex].IsBlue();
        
    }

    public void ChangeToBlue(int i)
    {
        buttonsArray[i].SetBlue();
    }

    public void ChangeToYellow(int nextNeighbourIndex)
    {
        buttonsArray[nextNeighbourIndex].SetYellow();
    }

 
}
