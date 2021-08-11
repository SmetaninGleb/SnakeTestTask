using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeMouthController : MonoBehaviour
{
    public SnakeColorController SnakeColorController;
    public GameStatesController GameStateController;

    private Transform _snakeHead;

    private void Start()
    {
        _snakeHead = transform.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MoveByConeColliding moveByCone))
        {
            moveByCone.MoveToTransform(_snakeHead);
            moveByCone.WasInCone = true;
        }
    }
}
