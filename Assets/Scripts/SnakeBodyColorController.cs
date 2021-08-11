using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyColorController : MonoBehaviour
{
    public ColorController ColorController;
    private SnakeColorController _snakeColorController;
    private GameStatesController _gameStatesController;

    private Material _bodySectionMat;

    void Start()
    {
        _snakeColorController = transform.parent.GetComponent<SnakeColorController>();
        _gameStatesController = _snakeColorController.GameStatesController;
        _bodySectionMat = GetComponent<Renderer>().material;
        _bodySectionMat.color = transform.parent.GetChild(transform.GetSiblingIndex()-1).GetComponent<Renderer>().material.color;
        _gameStatesController.TapToStartOnEvent += ApplySnakeHeadColor;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ColorChanger changer))
        {
            _bodySectionMat.color = ColorController.GetColorByEnum(changer.Color);
        }
    }

    private void ApplySnakeHeadColor()
    {
        _bodySectionMat.color = ColorController.GetColorByEnum(_snakeColorController.CurrentColor);
    }
}
