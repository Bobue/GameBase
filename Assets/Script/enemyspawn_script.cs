using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawn_script : MonoBehaviour
{
    public GameObject prefabToSpawn; // ������ ������
    public Transform spawnArea; // ���� ������ ������ ������Ʈ
    public float initialSpawnInterval = 1f; // �ʱ� ���� �ֱ�
    public float minXOffset = -5f; // ���� ���� �� �ּ� X ������
    public float maxXOffset = 5f; // ���� ���� �� �ִ� X ������
    public float intervalDecrement = 0.05f; // ���� �ֱ⸦ ���̴� ��
    public float minSpawnInterval = 0.1f; // �ּ� ���� �ֱ�

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

            // ���� �� ���� ��ġ ���
            float xOffset = Random.Range(minXOffset, maxXOffset);
            Vector3 spawnPosition = new Vector3(spawnArea.position.x + xOffset, spawnArea.position.y, spawnArea.position.z);

            // ������ ����
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            // ���� �ֱ� ����, �ּ� ���� �ֱ� ���Ϸδ� �پ���� �ʵ���
            if (currentSpawnInterval > minSpawnInterval)
            {
                currentSpawnInterval -= intervalDecrement;
                currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);
            }
        }
    }
}
