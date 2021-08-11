using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatesController : MonoBehaviour
{

    private bool _isGameOn;
    public bool IsGameOn => _isGameOn;
    private bool _isTapToStart;
    public bool IsTapToStart => _isTapToStart;
    private bool _isGameOver;
    public bool IsGameOver => _isGameOver;

    public delegate void StartGameHandler();
    public delegate void TapToStartOnHandler();
    public delegate void GameOverHandler();

    public event StartGameHandler StartGameEvent;
    public event TapToStartOnHandler TapToStartOnEvent;
    public event GameOverHandler GameOverEvent;

    void Start()
    {
        _isGameOn = false;
        _isGameOver = false;
        _isTapToStart = true;
    }
    
    public void GameOver()
    {
        _isGameOver = true;
        _isGameOn = false;
        _isTapToStart = false;
        GameOverEvent?.Invoke();
    }

    public void TapToStartOn()
    {
        _isGameOver = false;
        _isGameOn = false;
        _isTapToStart = true;
        TapToStartOnEvent?.Invoke();
    }

    public void StartGame()
    {
        _isGameOver = false;
        _isGameOn = true;
        _isTapToStart = false;
        StartGameEvent?.Invoke();
    }
}
