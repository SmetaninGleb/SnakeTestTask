using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{

    [SerializeField]
    private int _pointsCount;
    [SerializeField]
    private float _lengthByPoint;

    private SnakeBodyMovement _snakeBodyMovement;

    void Start()
    {
        _pointsCount = 0;
        _snakeBodyMovement = GetComponent<SnakeBodyMovement>();
    }

    public void AddPoints(int points)
    {
        _pointsCount += points;
        _snakeBodyMovement.SnakeLength += _lengthByPoint * points;
    }
}
