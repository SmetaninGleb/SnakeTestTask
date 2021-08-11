using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStartButton : MonoBehaviour
{

    public GameStatesController StateController;

    void Start()
    {
        StateController.StartGameEvent += DisableTapToStartBtn;
        StateController.TapToStartOnEvent += EnableTapToStartBtn;
    }
    
    void DisableTapToStartBtn()
    {
        gameObject.SetActive(false);
    }

    void EnableTapToStartBtn()
    {
        gameObject.SetActive(true);
    }

}
