using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public ColorController.Color Color;
    public ParticleSystem[] particleSystems;
    public ColorController ColorController;

    private void Start()
    {
        foreach(ParticleSystem particles in particleSystems)
        {
            particles.startColor = ColorController.GetColorByEnum(Color);
            particles.Play();
        }
    }
}
