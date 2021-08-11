using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeColorController : MonoBehaviour
{
    public ColorController.Color CurrentColor;
    private Material _snakeMaterial;
    public ColorController ColorController;
    public GameStatesController GameStatesController;
    private ColorController.Color _startColor;

    void Start()
    {
        _startColor = CurrentColor;
        _snakeMaterial = GetComponent<Renderer>().material;
        Color32 snakeColor = ColorController.GetColorByEnum(CurrentColor);
        _snakeMaterial.color = snakeColor;
        foreach(Renderer childRenderer in gameObject.GetComponentsInChildren<Renderer>())
        {
            childRenderer.material.color = snakeColor;
        }
        GameStatesController.TapToStartOnEvent += ApplyStartColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ColorChanger changer))
        {
            ChangeColor(changer.Color);
        }
    }

    void ChangeColor(ColorController.Color newColor)
    {
        CurrentColor = newColor;
        _snakeMaterial.color = ColorController.GetColorByEnum(newColor);
    }

    private void ApplyStartColor()
    {
        CurrentColor = _startColor;
        _snakeMaterial.color = ColorController.GetColorByEnum(_startColor);
    }
}
