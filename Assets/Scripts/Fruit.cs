using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private ParticleSystem particlePrefab;

    void OnTriggerEnter2D(Collider2D collider) {
        if (GameManager.Instance.GetGameOver()) { // 게임이 끝났으면 return;
            Invisible();
            return;
        }

        if (collider.CompareTag("Player")) {
            Invisible();
            PlayerController player = collider.GetComponent<PlayerController>();
            if (player != null) {
                if (player.GetShield()) {
                    player.DestoryShield();
                } else { // 만약 쉴드가 없으면
                    GameManager.Instance.GameOver();
                }
            }
        }

        if (collider.CompareTag("Ground")) {
            Invisible();
            GameManager.Instance.AddScore();
        }
    }

    void Invisible() {
        Instantiate<ParticleSystem>(particlePrefab, transform.position, Quaternion.identity).Play();
        GetComponent<AudioSource>().Play(); // 과일 부셔지는 소리 재생
        GetComponent<SpriteRenderer>().enabled = false; // 충돌 시 이미지 안 보이게 비활성화
        GetComponent<Collider2D>().enabled = false; // 만약 플레이어와 충돌했을 경우, 바닥과 또 충돌하므로 Collider 비활성화
        Destroy(gameObject, 1f); // 바로 Destroy하면 소리가 재생이 안되므로 1초 뒤 삭제 
    }
}
