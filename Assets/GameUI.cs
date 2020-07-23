using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private Text coins;
    [SerializeField] private Text world;
    [SerializeField] private Text time;

    private void OnEnable()
    {
        ScoreManager.OnCoinsUpdate += UpdateCoins;
        ScoreManager.OnScoreUpdate += UpdateScore;
        ScoreManager.OnTimeUpdate += UpdateTime;
    }

    private void OnDisable()
    {
        ScoreManager.OnCoinsUpdate -= UpdateCoins;
        ScoreManager.OnScoreUpdate -= UpdateScore;
        ScoreManager.OnTimeUpdate -= UpdateTime;
    }

    private void UpdateCoins(int count)
    {
        coins.text = string.Format("{0:00}", count);
    }

    private void UpdateScore(int count)
    {
        score.text = string.Format("{0:000000}", count);
    }

    private void UpdateTime(int count)
    {
        time.text = count.ToString();
    }
}
