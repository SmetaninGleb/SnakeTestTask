using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionController : MonoBehaviour
{
    public GameStatesController GameStateController;
    private FeverController _feverController;
    private PointsController _pointsController;

    private void Start()
    {
        _feverController = GetComponent<FeverController>();
        _pointsController = GetComponent<PointsController>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            if (!_feverController.IsFever)
            {
                GameStateController.GameOver();
            } else
            {
                _pointsController.AddPoints(obstacle.PointsForEating);
                obstacle.gameObject.SetActive(false);
            }
        }
    }
}
