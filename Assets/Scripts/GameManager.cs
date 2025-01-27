using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // 속성 값 읽기 가능, 값 설정은 내부에서만 가능
    [SerializeField] private GameObject gameOverPanel;
    private int score = 0;
    private bool isGameOver = false;

    void Start() {
        gameOverPanel.SetActive(false);

        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void AddScore() {
        score++;
        HUDManager.Instance.UpdateScore(score);
    }
    
    public void GameOver() {
        gameOverPanel.SetActive(true);
        isGameOver = true;

        TextMeshProUGUI finalScore = gameOverPanel.transform.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();
        if (finalScore != null) {
            finalScore.text = $"점수 : {score} 점";
        }

        FruitSpawner fruitSpawner = FindObjectOfType<FruitSpawner>();
        if (fruitSpawner != null) {
            fruitSpawner.StopSpawn();
        }

        ItemSpawner itemSpawner = FindObjectOfType<ItemSpawner>();
        if (itemSpawner != null) {
            itemSpawner.StopSpawn();
        }
    }

    public bool GetGameOver() {
        return isGameOver;
    }

    public void LoadGameScene() {
        SceneManager.LoadScene("Scenes/GameScene");
    }

    public void LoadMenuScene() {
        SceneManager.LoadScene("Scenes/MenuScene");
    }
}
