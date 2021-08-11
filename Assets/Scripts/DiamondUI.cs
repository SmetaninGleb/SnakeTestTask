using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondUI : MonoBehaviour
{
    public Text DiamondNumberText;
    public DiamondController DiamondController;
    public GameStatesController GameStatesController;

    void Start()
    {
        DiamondNumberText.text = DiamondController.DiamondCount.ToString();
        GameStatesController.StartGameEvent += EnableDiamondUI;
        GameStatesController.GameOverEvent += DisableDiamondUI;
        DisableDiamondUI();
    }

    // Update is called once per frame
    void Update()
    {
        DiamondNumberText.text = DiamondController.DiamondCount.ToString();
    }

    private void EnableDiamondUI()
    {
        gameObject.SetActive(true);
    }

    private void DisableDiamondUI()
    {
        gameObject.SetActive(false);
    }
}
