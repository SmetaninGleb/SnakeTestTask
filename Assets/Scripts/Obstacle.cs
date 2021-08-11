using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameStatesController GameStatesController;
    public int PointsForEating;

    private void Start()
    {
        GameStatesController.TapToStartOnEvent += SetActive;
    }

    private void SetActive()
    {
        gameObject.SetActive(true);
    }
}
