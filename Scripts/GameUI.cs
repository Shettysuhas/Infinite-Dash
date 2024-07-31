using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button exitButton, restartButton;
    private const string gameScene = "GameScene";

    private void OnEnable()
    {
        exitButton.onClick.AddListener(OnExitButtonClicked);
        restartButton.onClick.AddListener(OnrestartButtonClicked);
    }

    private void OnDisable()
    {
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
        restartButton.onClick.RemoveListener(OnrestartButtonClicked);
    }
    private void OnExitButtonClicked()
    {
        Application.Quit();
    }

    private void OnrestartButtonClicked()
    {
        SceneManager.LoadScene(gameScene);
    }
}
