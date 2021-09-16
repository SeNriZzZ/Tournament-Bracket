using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private ColumnController _columnPrefab;
    private int _playerCont;

    private ColumnController[] columnsArray;
    
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
            number = number >> 1; //здвигає біт вбік до тих пір поки number не буде 0. типу 000100 -> 000010 і так далі, 16 стає 8, а потім 4 і т.д.
            pow++;
        }

        return pow - 1;
    }
    
    public void Initialize(int players)
    {
        var playersCount = players; // задаємо гравців
        var pow = GetPow(playersCount); //вираховує в якій ступені число
        var columns = 2 * pow;
        columnsArray = new ColumnController[columns];
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
            
            columnsArray[i] = BuildColumn(buttonsToCreate, i);
            
        }
        
    }
    
    

    public ColumnController BuildColumn(int buttonsToCreate, int i)
    {

            ColumnController childObject = Instantiate(_columnPrefab);
            childObject.transform.parent = this.transform;
            childObject.Initialize(buttonsToCreate, i);
            childObject.OnClick += OnButtonClicked;
            return childObject;
    }
    
    private void OnButtonClicked(int buttonIndex, int columnIndex)
    {
        var column = columnsArray[columnIndex];
        
        var buttons = column.GetButtonsCount();
        int buttonsCount = buttons;
        
        var isPair = buttonIndex % 2 == 0;
        int neighbourIndex = 0;
        if (isPair)
        {
            neighbourIndex = buttonIndex + 1;

        }
        else
        {
            neighbourIndex = buttonIndex - 1;
        }
        var isNeighbourPair = neighbourIndex % 2 == 0;
        int nextNeighbourIndex = 0;
        if (isNeighbourPair)
        {
            nextNeighbourIndex = neighbourIndex + 1;
        }
        else
        {
            nextNeighbourIndex = neighbourIndex - 1;
        }

        if (buttonsCount == 1 && column.IsBlue(buttonIndex))
        {
            
            bool lastColumnIsLeftSide;
            int halfArraySize = columnsArray.Length / 2;
            if (columnIndex  < halfArraySize)
            {
                lastColumnIsLeftSide = true;
            }
            else
            {
                lastColumnIsLeftSide = false;
            }

            int lastColumnIndex = 0;
            if (lastColumnIsLeftSide == true)
            {
                lastColumnIndex = columnIndex + 1;
                
            }
            else
            {
                lastColumnIndex = columnIndex - 1;
                
            }

            if (columnsArray[lastColumnIndex].IsBlue(0))
            {
                column.ChangeToYellow(buttonIndex);
                columnsArray[lastColumnIndex].ChangeToBlack(0);
            }
            
        }
        else
        {
            if (column.IsBlue(neighbourIndex) && column.IsBlue(buttonIndex) && column.IsBlue(nextNeighbourIndex))
            {
                column.ChangeToBlack(neighbourIndex);
                column.ChangeToYellow(nextNeighbourIndex);



                bool isLeftSide;
                var halfArrSize = columnsArray.Length / 2;
                if (columnIndex + 1 < halfArrSize)
                {
                    isLeftSide = true;
                }
                else
                {
                    isLeftSide = false;
                }

                int nextColumnIndex = 0;
                if (isLeftSide == true)
                {
                    nextColumnIndex = columnIndex + 1;

                }
                else
                {
                    nextColumnIndex = columnIndex - 1;

                }

                var x = 0;
                var nextColumnButtonIndex = buttonIndex;
                if (buttonIndex % 2 == 1)
                {
                    nextColumnButtonIndex--;

                }


                x = nextColumnButtonIndex / 2;

                // x is the actual nextColumnButtonIndex;
                columnsArray[nextColumnIndex].ChangeToBlue(x);


            }


        }
    }
    
}
