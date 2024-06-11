using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class LifeManager : MonoBehaviour
{
    public static LifeManager instance; // 싱글톤 인스턴스
    public Text scoreText; // 점수를 표시할 UI 텍스트
    private int Life = 5; // 현재 점수
    public GameObject gameOverPanel; // 게임 오버 패널
    public Text gameOverScoreText; // 게임 오버 시 표시할 점수 텍스트
    public static int growscore; //메인씬으로 넘겨줄 점수값


    void Awake()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        // 싱글톤 인스턴스 설정
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        Life -= amount;
        scoreText.text = "Life: " + Life.ToString();

        if (Life <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        // 게임 오버 패널 활성화
        gameOverPanel.SetActive(true);
        int finalScore = ScoreManager.instance.GetScore();
        gameOverScoreText.text = "Score: " + finalScore.ToString();
        growscore = finalScore;
        // 게임을 멈춤
        Time.timeScale = 0f;


    }
}
