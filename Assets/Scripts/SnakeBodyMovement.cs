using BansheeGz.BGSpline.Curve;
using BansheeGz.BGSpline.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyMovement : MonoBehaviour
{

    public float SnakeLength;

    [SerializeField]
    private float _distanceBetweenSections;

    [SerializeField]
    private BGCurve _pathCurve;
    [SerializeField]
    private GameObject _bodySectionPrefab;

    private List<GameObject> _bodySections;

    public GameStatesController GameStatesController;

    private float _startSnakeLength;

    void Start()
    {
        _startSnakeLength = SnakeLength;
        _bodySections = new List<GameObject>();
        while ((_bodySections.Count + 1) * _distanceBetweenSections <= SnakeLength)
        {
            GameObject newSection = GameObject.Instantiate(_bodySectionPrefab, transform);
            _bodySections.Add(newSection);
        }
        GameStatesController.TapToStartOnEvent += ClearBodySections;
    }

    // Update is called once per frame
    void Update()
    {
        while ((_bodySections.Count + 1) * _distanceBetweenSections <= SnakeLength)
        {
            GameObject newSection = GameObject.Instantiate(_bodySectionPrefab, transform);
            _bodySections.Add(newSection);
        }
        
        BGCcMath curveMath = _pathCurve.GetComponent<BGCcMath>();
        float distanceForHead = curveMath.GetDistance();
        for (int i = 0; i < _bodySections.Count; i++)
        {
            float distanceForSection = distanceForHead - (i+1) * _distanceBetweenSections;
            _bodySections[i].transform.position = curveMath.CalcPositionByDistance(distanceForSection);
            Vector3 tangent = curveMath.CalcTangentByDistance(distanceForSection);
            if (tangent != Vector3.zero)
            {
                _bodySections[i].transform.rotation = Quaternion.LookRotation(tangent);
            }
        }
    }

    private void ClearBodySections()
    {
        foreach (GameObject section in _bodySections)
        {
            GameObject.Destroy(section);
        }
        _bodySections.Clear();
        SnakeLength = _startSnakeLength;
    }
}
