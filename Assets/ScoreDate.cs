using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDate : MonoBehaviour
{
    [Header(">创建一个新的Int值，然后拖放对应的text<")]
    public ScoreValue[] ScoreText;
    void Start()
    {
        ScoreValueChange += GetNewScore;
        for (int i = 0; i < ScoreText.Length; i++)
        {
            ScoreText[i].id = i;
        }
    }

    public static Action<int> ScoreValueChange;
    private void GetNewScore(int ID)
    {
        for (int i = 0; i < ScoreText.Length; i++)
        {
            if (ScoreText[i].id == ID)
            {
                // 更新UI显示
                if (ScoreText[i].text != null)
                {
                    ScoreText[i].text.text = ScoreText[i].ScoreNum.ToString();
                }
                break;
            }
        }
    }
    void OnDestroy()
    {
        ScoreValueChange -= GetNewScore;
    }
}
[System.Serializable]
public class ScoreValue
{
    [Tooltip("该Int值的名字")]
    public string name;
    public int id;
    public int ScoreNum
    {
        get { return mScoreNum; }
        set
        {
            if (value != mScoreNum)
            {
                mScoreNum = value;
                Debug.Log("分数变化！");
                ScoreDate.ScoreValueChange?.Invoke(id);
            }
        }
    }
    private int mScoreNum;
    public Text text;
}
