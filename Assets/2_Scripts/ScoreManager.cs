using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class ScoreManager : MonoBehaviour
{
    private struct ScoreData
    {
        public string str;
        public Color color;
        public Vector2 pos;
    }
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreTmp;
    [SerializeField] private TextMeshProUGUI bonusTmp;
    [SerializeField] private Score baseScore;
    private List<ScoreData> scoreDataList = new List<ScoreData>();

    private int totalScore;
    private float totalBonus;
    public void lnit()
    {
        instance = this;
        StartCoroutine(OnScoreCor());
    }
    private IEnumerator OnScoreCor()
    {
        while(true)
        {
            if(scoreDataList.Count > 0)
            {
                ScoreData data = scoreDataList[0];

                Score scoreObj = Instantiate<Score>(baseScore);
                scoreObj.transform.position = data.pos;
                scoreObj.Active(data.str, data.color);

                scoreDataList.RemoveAt(0);
                yield return new WaitForSeconds(DataBaseManager.Instance.ScorePopInterval);
            }
            else
            {
                yield return null;
            }
        }
    }
    public void AddScore(int score, Vector2 scorePos, bool isCalcBouns=true)
    {
        //애니
        scoreDataList.Add(new ScoreData()
        {
            str = score.ToString(),
            color = DataBaseManager.Instance.ScoreColor,
            pos = scorePos
        });
        //Canvas
        totalScore += score;
        scoreTmp.text = totalScore.ToString();

        if (isCalcBouns)
        {
            int bonusScore = (int)(score * totalBonus);
            AddScore(bonusScore,scorePos,false);
        }
    }
    internal void AddBonus(float bonus, Vector2 position)
    {
        scoreDataList.Add(new ScoreData()
        {
            str = "Bouns " + bonus.ToPercentString(),
            color = DataBaseManager.Instance.BonusColor,
            pos = position
        });

        totalBonus += bonus;
        bonusTmp.text = totalBonus.ToPercentString();
    }
    internal void ResetBonus(Vector2 bonusPos)
    {
        scoreDataList.Add(new ScoreData()
        {
            str = "Bouns 초기화" ,
            color = DataBaseManager.Instance.BonusColor,
            pos = bonusPos
        });

        totalBonus = 0;
        bonusTmp.text = totalBonus.ToPercentString();
    }
}
