using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // �̱��� �ν��Ͻ�
    public Text scoreText; // ������ ǥ���� UI �ؽ�Ʈ
    private int score = 0; // ���� ����

    void Awake()
    {
        // �̱��� �ν��Ͻ� ����
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
}
