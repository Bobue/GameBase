using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어 이동 속도
    public GameObject bullet; // 발사할 프리팹
    public float projectileSpeed = 10f; // 발사체 속도
    public float minX = -10f; // 왼쪽 경계
    public float maxX = 10f; // 오른쪽 경계

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // 방향키 입력에 따라 플레이어 이동
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * moveSpeed * Time.deltaTime;
        Vector2 newPosition = rb.position + Vector2.right * move * moveSpeed * Time.deltaTime;
        // 플레이어의 위치를 경계 내로 제한
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // 스페이스바를 눌렀을 때 발사체 생성
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bullet != null)
        {
            // 플레이어 위치에서 발사체 생성
            GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity);

            // 발사체에 힘을 가하여 앞으로 날아가게 함
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(0, projectileSpeed);
            }
        }
    }
}
