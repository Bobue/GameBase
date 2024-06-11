using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour
{
    public GameObject seed;
    public GameObject grade_1;
    public GameObject grade_2;
    public GameObject grade_3;
    public GameObject last; // 게임 종료 패널

    private void Start()
    {
        if (LifeManager.growscore > 0 && LifeManager.growscore < 100)
            MakeVisible(1);
        if (LifeManager.growscore >= 100 && LifeManager.growscore < 150)
            MakeVisible(2);
        if (LifeManager.growscore > 150)
            MakeVisible(3);
    }
    public void MakeVisible(int objectNumber)
    {
        if (objectNumber == 1 && grade_1 != null)
        {
            seed.SetActive(false);
            grade_1.SetActive(true);
            grade_2.SetActive(false);
            grade_3.SetActive(false);
        }
        if (objectNumber == 2 && grade_2 != null)
        {
            seed.SetActive(false);
            grade_1.SetActive(false);
            grade_2.SetActive(true);
            grade_3.SetActive(false);
        }
        else if (objectNumber == 3 && grade_3 != null)
        {
            seed.SetActive(false);
            grade_1.SetActive(false);
            grade_2.SetActive(false);
            grade_3.SetActive(true);
            last.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}