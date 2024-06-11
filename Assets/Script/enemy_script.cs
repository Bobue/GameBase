using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_script : MonoBehaviour
{
    public float speed = 1f; // �̵� �ӵ�
    public int scoreValue = 10; // �� ������Ʈ�� �ִ� ����
    public int LifeValue = 1; // ���� ��� ���̴� ����
    void Update()
    {
        // �Ʒ��� �̵�
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            ScoreManager.instance.AddScore(scoreValue); // ���� ����
            Destroy(gameObject);
        }
        if (collision.CompareTag("line"))
        {
            Destroy(gameObject);
            LifeManager.instance.AddScore(LifeValue); // ���� ����            
        }
    }
}
