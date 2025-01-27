using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; } // 속성 값 읽기 가능, 값 설정은 내부에서만 가능
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject shieldImage;
    private Image image;

    void Start() {
        image = shieldImage.GetComponent<Image>();
        image.enabled = false;

        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
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
}
