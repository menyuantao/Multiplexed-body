using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private ScoreDate scoreDate;
    void Start()
    {
        scoreDate = FindObjectOfType<ScoreDate>();
        if(scoreDate == null)Debug.LogWarning("未找到数据!");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            scoreDate.ScoreText[0].ScoreNum++;
            Debug.Log(scoreDate.ScoreText[0].ScoreNum);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            scoreDate.ScoreText[1].ScoreNum++;
        }
    }
}
