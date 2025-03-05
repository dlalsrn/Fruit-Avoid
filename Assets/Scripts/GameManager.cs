using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // 속성 값 읽기 가능, 값 설정은 내부에서만 가능
    private int score = 0;
    private bool isGameOver = false;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        HUDManager.Instance.HideGameOverPanel();
    }

    public void AddScore() {
        score++;
        HUDManager.Instance.UpdateScore(score);
    }
    
    public void GameOver() {
        HUDManager.Instance.ShowGameOverPanel();

        isGameOver = true;

        HUDManager.Instance.SetFinalScoreText(score);

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
