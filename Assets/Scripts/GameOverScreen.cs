using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameStatesController GameStatesController;

    void Start()
    {
        GameStatesController.GameOverEvent += EnableGameOverScreen;
        GameStatesController.TapToStartOnEvent += DisableGameOverScreen;
        gameObject.SetActive(false);
    }
    
    private void DisableGameOverScreen()
    {
        gameObject.SetActive(false);
    }

    private void EnableGameOverScreen()
    {
        gameObject.SetActive(true);
    }
}
