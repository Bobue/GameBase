using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawn_script : MonoBehaviour
{
    public GameObject prefabToSpawn; // 생성할 프리팹
    public Transform spawnArea; // 생성 범위를 정의할 오브젝트
    public float initialSpawnInterval = 1f; // 초기 생성 주기
    public float minXOffset = -5f; // 생성 범위 내 최소 X 오프셋
    public float maxXOffset = 5f; // 생성 범위 내 최대 X 오프셋
    public float intervalDecrement = 0.05f; // 생성 주기를 줄이는 양
    public float minSpawnInterval = 0.1f; // 최소 생성 주기

    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnPrefab());
    }

    IEnumerator SpawnPrefab()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnInterval);

            // 범위 내 랜덤 위치 계산
            float xOffset = Random.Range(minXOffset, maxXOffset);
            Vector3 spawnPosition = new Vector3(spawnArea.position.x + xOffset, spawnArea.position.y, spawnArea.position.z);

            // 프리팹 생성
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            // 생성 주기 감소, 최소 생성 주기 이하로는 줄어들지 않도록
            if (currentSpawnInterval > minSpawnInterval)
            {
                currentSpawnInterval -= intervalDecrement;
                currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);
            }
        }
    }
}
