using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private Button restartButton;

    private void Start()
    {
        gameOverWindow.SetActive(false);
        restartButton.onClick.AddListener(RestartScene);

        gameState.OnGameOver += () => gameOverWindow.SetActive(true);
    }

    private void RestartScene()
    {
        string currentName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentName);
    }
}
