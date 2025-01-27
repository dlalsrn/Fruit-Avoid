using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item[] itemPrefabs;
    private float minX = -2.5f;
    private float maxX = 2.5f;
    private const float INTERVAL = 7f; // 아이템 생성 주기

    void Start() {
        StartSpawn();
    }

    void StartSpawn() {
        StartCoroutine("ItemSpawn");
    }

    public void StopSpawn() {
        StopCoroutine("ItemSpawn");
    }

    IEnumerator ItemSpawn() {
        yield return new WaitForSeconds(INTERVAL);

        while (true) {
            int index = UnityEngine.Random.Range(0, itemPrefabs.Length);
            float xPos = UnityEngine.Random.Range(minX, maxX); // 화면 가로 [최소, 최대] 사이의 값
            Vector3 pos = new Vector3(xPos, transform.position.y, transform.position.z);
            Instantiate<Item>(itemPrefabs[0], pos, Quaternion.identity);
            yield return new WaitForSeconds(INTERVAL);
        }
    }
}
