using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUi : MonoBehaviour
{
    [SerializeField] private Button exitButton, playButton;

    private const string gameScene = "GameScene";

    private void OnEnable()
    {
        exitButton.onClick.AddListener(OnExitButtonClicked);
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnDisable()
    {
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(gameScene);
    }
}
