using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // 싱글톤 인스턴스
    public Text scoreText; // 점수를 표시할 UI 텍스트
    private int score = 0; // 현재 점수

    void Awake()
    {
        // 싱글톤 인스턴스 설정
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
