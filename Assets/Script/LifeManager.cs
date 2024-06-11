using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class LifeManager : MonoBehaviour
{
    public static LifeManager instance; // �̱��� �ν��Ͻ�
    public Text scoreText; // ������ ǥ���� UI �ؽ�Ʈ
    private int Life = 5; // ���� ����
    public GameObject gameOverPanel; // ���� ���� �г�
    public Text gameOverScoreText; // ���� ���� �� ǥ���� ���� �ؽ�Ʈ
    public static int growscore; //���ξ����� �Ѱ��� ������


    void Awake()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        // �̱��� �ν��Ͻ� ����
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
        // ���� ���� �г� Ȱ��ȭ
        gameOverPanel.SetActive(true);
        int finalScore = ScoreManager.instance.GetScore();
        gameOverScoreText.text = "Score: " + finalScore.ToString();
        growscore = finalScore;
        // ������ ����
        Time.timeScale = 0f;


    }
}
