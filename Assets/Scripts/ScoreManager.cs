using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int playerScore;
    public int enemyScore;
    
    public Text playerScoreText;
    public Text enemyScoreText;
    
    private void OnEnable()
    {
        instance = this;
    }

    public void PlayerGoal()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }

    public void EnemyGoal()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
    }
}
