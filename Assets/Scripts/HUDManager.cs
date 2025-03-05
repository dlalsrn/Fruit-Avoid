using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; } // 속성 값 읽기 가능, 값 설정은 내부에서만 가능
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject shieldImage;
    private Image image;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        image = shieldImage.GetComponent<Image>();
        image.enabled = false;
    }
    
    public void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
    }

    public void HideGameOverPanel() {
        gameOverPanel.SetActive(false);
    }

    public void UpdateScore(int score) {
        scoreText.text = $"Score {score}";
    }
    
    public void CreateShield() {
        image.enabled = true;
    }
    
    public void DestoryShield() {
        image.enabled = false;
    }

    public void SetFinalScoreText(int score) {
        TextMeshProUGUI finalScore = gameOverPanel.transform.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();
        finalScore.text = $"점수 : {score} 점";
    }
}
