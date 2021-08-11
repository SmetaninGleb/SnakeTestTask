using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class SnakeHeadController : MonoBehaviour
{

    public float ForwardSpeed;
    public float XCorRange;
    public float MaxDpiMove;

    [SerializeField]
    private GameStatesController _stateController;

    public delegate void MoveByXDone();
    public event MoveByXDone MoveByXEvent;

    private Vector3 _startPosition;

    private FeverController _feverController;

    private void Start()
    {
        _startPosition = transform.position;
        _feverController = GetComponent<FeverController>();
    }

    void Update()
    {
        if (_stateController.IsTapToStart)
        {
            transform.SetPositionAndRotation(_startPosition, Quaternion.identity);
        }

        if (!_stateController.IsGameOn) return;

        //Side move
        float newX = transform.position.x;
        float previousX = transform.position.x;
        if (!_feverController.IsFever)
        {
            foreach (LeanFinger finger in LeanTouch.Fingers)
            {
                if (finger.ScaledDelta.x != 0)
                {
                    if (finger.ScaledDelta.x < 0)
                    {
                        newX = transform.position.x - XCorRange * (finger.ScaledDelta.x / -MaxDpiMove);
                        newX = Mathf.Max(-XCorRange, newX);
                    }
                    else
                    {
                        newX = transform.position.x + XCorRange * (finger.ScaledDelta.x / MaxDpiMove);
                        newX = Mathf.Min(XCorRange, newX);
                    }
                }
            }
        } else
        {
            newX = 0f;
        }
        //Applying new position and rotation
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + ForwardSpeed * Time.deltaTime);
        Quaternion newQuaternion = Quaternion.LookRotation(newPosition - transform.position);
        transform.SetPositionAndRotation(newPosition, newQuaternion);
        if (previousX != newX)
        {
            MoveByXEvent();
        }
    }
}
