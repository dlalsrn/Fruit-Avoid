using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private Fruit[] fruitPrefabs;
    private float minX = -2.5f;
    private float maxX = 2.5f;
    private float interval = 1f; // 과일 생성 주기

    void Start()
    {
        StartSpawn();
    }

    void Update() {
        if (interval > 0.15) {
            interval -= 0.05f * Time.deltaTime;
        }
    }

    void StartSpawn() {
        StartCoroutine("FruitSpawn");
    }

    public void StopSpawn() {
        StopCoroutine("FruitSpawn");
    }

    IEnumerator FruitSpawn() {
        yield return new WaitForSeconds(0.5f);

        while (true) {
            int index = UnityEngine.Random.Range(0, fruitPrefabs.Length);
            float xPos = UnityEngine.Random.Range(minX, maxX); // 화면 가로 [최소, 최대] 사이의 값
            Vector3 pos = new Vector3(xPos, transform.position.y, transform.position.z);
            Instantiate<Fruit>(fruitPrefabs[index], pos, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

    public void IncreaseInterval() {
        interval += 0.3f;
    }
}
