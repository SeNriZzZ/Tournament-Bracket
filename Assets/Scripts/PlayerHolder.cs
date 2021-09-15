using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHolder : MonoBehaviour
{
    public int players;
    private MainMenuController _mainMenuController;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);    
    }

    private void Start()
    {
        _mainMenuController = FindObjectOfType<MainMenuController>();
    }
    
    public void GetPlayerCount()
    {
        players = _mainMenuController.GetPlayers(players);
        Debug.Log(players);
    }
}
