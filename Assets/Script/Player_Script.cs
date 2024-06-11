using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�
    public GameObject bullet; // �߻��� ������
    public float projectileSpeed = 10f; // �߻�ü �ӵ�
    public float minX = -10f; // ���� ���
    public float maxX = 10f; // ������ ���

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // ����Ű �Է¿� ���� �÷��̾� �̵�
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * moveSpeed * Time.deltaTime;
        Vector2 newPosition = rb.position + Vector2.right * move * moveSpeed * Time.deltaTime;
        // �÷��̾��� ��ġ�� ��� ���� ����
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // �����̽��ٸ� ������ �� �߻�ü ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bullet != null)
        {
            // �÷��̾� ��ġ���� �߻�ü ����
            GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity);

            // �߻�ü�� ���� ���Ͽ� ������ ���ư��� ��
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(0, projectileSpeed);
            }
        }
    }
}
