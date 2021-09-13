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

    private int _numberOfPlayers;

    void Update()
    {
        _numberOfPlayers = Int32.Parse(_playerCount.text);
        if (Mathf.Log(_numberOfPlayers,2) % 1 ==0)
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
        SceneManager.LoadScene("Tournament");
    }

}
