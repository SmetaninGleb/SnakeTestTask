using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public ColorController.Color Color;
    public int PointsForEating;
    public ColorController ColorController;
    
    void Start()
    {
        GetComponent<Renderer>().material.color = ColorController.GetColorByEnum(Color);
    }
}
