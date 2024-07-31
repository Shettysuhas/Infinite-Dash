using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PlayerMovement playerMovement;

    public static Action OnCoinCollected;
    private int score;

    private void OnEnable()
    {
        OnCoinCollected += Increment;
    }

    private void OnDisable()
    {
        OnCoinCollected -= Increment;
    }

    private void Increment()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        playerMovement.speed += playerMovement.speedIncreasePoint;
       
    }
}

