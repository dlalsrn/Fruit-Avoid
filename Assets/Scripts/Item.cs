using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType {
        Shield,
        SlowInterval
    }
    [SerializeField] private ItemType itemType;

    void OnTriggerEnter2D(Collider2D collider) {
        if (GameManager.Instance.GetGameOver()) { // 게임이 끝났으면 return;
            Invisible();
            return;
        }

        if (collider.CompareTag("Player")) {
            GetComponent<AudioSource>().Play(); // 아이템 획득 소리 재생
            Invisible();
            PlayerController player = collider.GetComponent<PlayerController>();

            if (player != null) {
                switch(itemType) {
                    case ItemType.Shield:
                        player.CreateShield();
                        break;
                    case ItemType.SlowInterval:
                        FruitSpawner fruitSpawner = FindObjectOfType<FruitSpawner>();
                        if (fruitSpawner != null) {
                            fruitSpawner.IncreaseInterval();
                        }
                        break;
                }
            }
        } else if (collider.CompareTag("Ground")) {
            Invisible();
        }
    }

    void Invisible() {
        GetComponent<SpriteRenderer>().enabled = false; // 충돌 시 이미지 안 보이게 비활성화
        GetComponent<Collider2D>().enabled = false; // 만약 플레이어와 충돌했을 경우, 바닥과 또 충돌하므로 Collider 비활성화
        Destroy(gameObject, 1f); // 바로 Destroy하면 소리가 재생이 안되므로 1초 뒤 삭제 
    }
}
