using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Curve;

public class SnakePathWriter : MonoBehaviour
{

    [SerializeField]
    private BGCurve _pathCurve;

    public GameStatesController StateController;

    private SnakeHeadController _headController;
    [SerializeField]
    private BGCurvePoint _lastCurvePoint;
    private bool _wasPointAddedAtFrame;

    void Start()
    {
        _wasPointAddedAtFrame = true;
        _headController = gameObject.GetComponent<SnakeHeadController>();
        _headController.MoveByXEvent += PutNewPointToCurve;
        StateController.TapToStartOnEvent += ClearPath;
    }

    private void Update()
    {

        if (_wasPointAddedAtFrame)
        {
            _lastCurvePoint = new BGCurvePoint(_pathCurve, transform.position, true);
            _pathCurve.AddPoint(_lastCurvePoint);
            _wasPointAddedAtFrame = false;
        } else
        {
            _lastCurvePoint.PositionWorld = transform.position;
        }
    }

    private void PutNewPointToCurve()
    {
        BGCurvePoint beforePoint = _lastCurvePoint;
        _lastCurvePoint = new BGCurvePoint(_pathCurve, transform.position, true);
        Vector3 newPointPosition = new Vector3(transform.position.x, beforePoint.PositionWorld.y, transform.position.z);
        _lastCurvePoint.PositionWorld = newPointPosition;
        _pathCurve.AddPoint(_lastCurvePoint);
        _wasPointAddedAtFrame = true;
    }

    private void ClearPath()
    {
        for (int i = _pathCurve.PointsCount-1; i > 0; i--)
        {
            _pathCurve.Delete(i);
        }
        _wasPointAddedAtFrame = true;
    }
}
