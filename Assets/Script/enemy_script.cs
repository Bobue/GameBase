using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_script : MonoBehaviour
{
    public float speed = 1f; // 이동 속도
    public int scoreValue = 10; // 적 오브젝트가 주는 점수
    public int LifeValue = 1; // 선에 닿아 깎이는 생명
    void Update()
    {
        // 아래로 이동
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            ScoreManager.instance.AddScore(scoreValue); // 점수 증가
            Destroy(gameObject);
        }
        if (collision.CompareTag("line"))
        {
            Destroy(gameObject);
            LifeManager.instance.AddScore(LifeValue); // 생명 감소            
        }
    }
}
