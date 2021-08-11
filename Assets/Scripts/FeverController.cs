using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverController : MonoBehaviour
{
    [SerializeField]
    private int _diamondToEat;
    [SerializeField]
    private float _forwardSpeedMultiplyer;
    [SerializeField]
    private float _feverTime;
    private int _diamondEaten;

    private SnakeHeadController _snakeHeadController;
    private EatingController _eatingController;
    private float _standartSpeed;
    public GameStatesController GameStatesController;
    public bool IsFever;

    private float _timeFeverStarted;

    private void Start()
    {
        IsFever = false;
        _snakeHeadController = GetComponent<SnakeHeadController>();
        _eatingController = GetComponent<EatingController>();
        _eatingController.DiamondEatenEvent += DiamondEaten;
        _standartSpeed = _snakeHeadController.ForwardSpeed;
        _diamondEaten = 0;
    }

    private void Update()
    {
        if ((IsFever && Time.realtimeSinceStartup - _timeFeverStarted >= _feverTime) || GameStatesController.IsGameOver)
        {
            StopFever();
        }

        if (_diamondEaten == _diamondToEat)
        {
            StartFever();
        }
    }

    private void StartFever()
    {
        IsFever = true;
        _timeFeverStarted = Time.realtimeSinceStartup;
        _snakeHeadController.ForwardSpeed = _forwardSpeedMultiplyer * _standartSpeed;
        _diamondEaten = 0;
    }

    private void StopFever()
    {
        IsFever = false;
        _snakeHeadController.ForwardSpeed = _standartSpeed;
        _diamondEaten = 0;
    }

    private void DiamondEaten()
    {
        if (!IsFever)
        {
            _diamondEaten++;
        }
    }
}
