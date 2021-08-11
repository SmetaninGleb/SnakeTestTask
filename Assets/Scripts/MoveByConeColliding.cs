using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByConeColliding : MonoBehaviour
{

    public bool WasInCone;
    private bool _isMoving;
    private Transform _transformMoveTo;
    [SerializeField]
    private float _movingSpeed;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    [SerializeField]
    GameStatesController GameStatesController;

    void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        WasInCone = false;
        _isMoving = false;
        GameStatesController.TapToStartOnEvent += AfterGameEnd;
    }

    private void Update()
    {
        if (_isMoving)
        {
            Vector3 vectorBetween = _transformMoveTo.position - transform.position;
            Vector3 movingVector = (_transformMoveTo.position - transform.position).normalized * _movingSpeed * Time.deltaTime;
            if (vectorBetween.magnitude < movingVector.magnitude)
            {
                transform.Translate(vectorBetween, Space.World);
            }
            else
            {
                transform.Translate(movingVector, Space.World);
            }
        }
    }

    public void MoveToTransform(Transform transformTo)
    {
        _isMoving = true;
        _transformMoveTo = transformTo;
    }

    private void AfterGameEnd()
    {
        WasInCone = false;
        _isMoving = false;
        gameObject.SetActive(true);
        transform.SetPositionAndRotation(_startPosition, _startRotation);
    }
}
