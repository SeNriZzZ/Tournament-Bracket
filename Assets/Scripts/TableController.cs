using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private ColumnController _columnPrefab;
    private int _playerCont;
    private void Start()
    {
      
        Debug.Log("Players: " + _playerCont);
        Debug.Log(this.transform.childCount + "Children");
        
    }

    private int GetPow(int number)
    {
        int pow = 0;
        while (number != 0)
        {
            number = number >> 1; //здвигає біт вбік до тих пір поки number не буде 0. типу 000100 -> 000010 і так далі. Типу 16 стає 8, а потім 4 і т.д.
            pow++;
        }

        return pow - 1;
    }
    
    public void Initialize(int players)
    {
        var playersCount = players; // задаємо гравців
        var pow = GetPow(playersCount); //вираховує в якій ступені число (2 в ступені 4 напрімер)
        var columns = 2 * pow;
        bool buildUpsideDown = false;
        for (int i = 0; i < columns; i++)
        {
            var buttonsToCreate = playersCount / 2;
            
            if (buildUpsideDown == false)
            {
                playersCount /= 2;
            }
            else
            {
                playersCount *= 2;
                buttonsToCreate = playersCount / 2;
            }
            if (buttonsToCreate == 0)
            {
                playersCount = 2;
                buttonsToCreate = playersCount / 2;
                buildUpsideDown = true;
                
            }
            
            BuildColumn(buttonsToCreate);
            
            
        }
        
    }
    
    

    public void BuildColumn(int buttonsToCreate)
    {

            ColumnController childObject = Instantiate(_columnPrefab);
            childObject.transform.parent = this.transform;
            childObject.Initialize(_playerCont, buttonsToCreate);

    }
    
}
