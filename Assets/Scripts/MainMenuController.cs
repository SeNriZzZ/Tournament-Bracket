using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    [SerializeField] private InputField _playerCount;

    public static int numberOfPlayers;
    

    private void Start()
    {
        _startButton.interactable = false;
        
    }

    private void Update()
    {
        numberOfPlayers = Int32.Parse(_playerCount.text);
        if (Mathf.Log(numberOfPlayers,2) % 1 ==0 && numberOfPlayers <=32)
        {
            _startButton.image.color = Color.white;
            _startButton.interactable = true;
            Debug.Log("OK");
        }
        else
        {
            _startButton.interactable = false;
            _startButton.image.color = Color.red;
        }
    }

    public void OnClickEvent()
    {
        if (_startButton.interactable == true)
        {
            SceneManager.LoadScene("Tournament");
        }
    }

    public void OnInputCLicked()
    {
        TouchScreenKeyboard.Open(_playerCount.text, TouchScreenKeyboardType.Default);
    }

    public int GetPlayers(int x)
    {
        x = numberOfPlayers;
        return x;
    }
}
