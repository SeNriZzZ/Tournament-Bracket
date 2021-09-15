using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentController : MonoBehaviour
{   
    [SerializeField]
    private TableController _tableController;
    
    private PlayerHolder _playerHolder;

    private void Start()
    {
        _playerHolder = FindObjectOfType<PlayerHolder>();
        _playerHolder.GetPlayerCount();
        Debug.Log("We have: " + _playerHolder.players);
        _tableController.Initialize(_playerHolder.players);
    }
}
