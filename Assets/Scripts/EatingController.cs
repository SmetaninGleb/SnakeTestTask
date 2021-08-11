using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingController : MonoBehaviour
{
    public GameStatesController GameStatesController;

    private SnakeColorController _snakeColorController;
    private PointsController _pointsController;
    private DiamondController _diamondController;
    private FeverController _feverController;

    public delegate void DiamondEaten();
    public event DiamondEaten DiamondEatenEvent;

    void Start()
    {
        _snakeColorController = GetComponent<SnakeColorController>();
        _pointsController = GetComponent<PointsController>();
        _diamondController = GetComponent<DiamondController>();
        _feverController = GetComponent<FeverController>();
    }

    private void OnCollisionStay(Collision collision)
    {
        Collider other = collision.collider;
        if (other.TryGetComponent(out MoveByConeColliding moveCone))
        {
            if (!moveCone.WasInCone) return;
            if (other.TryGetComponent(out Food food))
            {
                if (food.Color == _snakeColorController.CurrentColor || _feverController.IsFever)
                {
                    _pointsController.AddPoints(food.PointsForEating);
                    food.gameObject.SetActive(false);
                }
                else
                {
                    food.gameObject.SetActive(false);
                    GameStatesController.GameOver();
                }
            }
            if (other.TryGetComponent(out Diamond diamond))
            {
                _diamondController.DiamondCount += diamond.CountForDiamond;
                diamond.gameObject.SetActive(false);
                DiamondEatenEvent?.Invoke();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        if (other.TryGetComponent(out MoveByConeColliding moveCone))
        {
            if (!moveCone.WasInCone) return;
            if (other.TryGetComponent(out Food food))
            {
                if (food.Color == _snakeColorController.CurrentColor || _feverController.IsFever)
                {
                    _pointsController.AddPoints(food.PointsForEating);
                    food.gameObject.SetActive(false);
                }
                else
                {
                    food.gameObject.SetActive(false);
                    GameStatesController.GameOver();
                }
            }
            if (other.TryGetComponent(out Diamond diamond))
            {
                _diamondController.DiamondCount += diamond.CountForDiamond;
                diamond.gameObject.SetActive(false);
                DiamondEatenEvent?.Invoke();
            }
        }
    }
}
