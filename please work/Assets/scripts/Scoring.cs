using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Scoring : MonoBehaviour
{
    public enum Score
    {
        AiScore, PlayerScore
    }
    public GameObject PlayerGoal, AiGoal, UIManagerObj;
    public TextMeshProUGUI AiScoreTxt, PlayerScoreTxt;
    public uiManager uiManager;
    public int MaxScore;

    
    private int aiScore, playerScore;
    
    private void Start()
    {
        uiManager = UIManagerObj.GetComponent<uiManager>();
    }
    private int AiScore
    {
        get { return aiScore; }
        set
        {
            aiScore = value;
            if (value == MaxScore)
                uiManager.ShowRestartCanvas(true);
        }
    }

    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            playerScore = value;
            if (value == MaxScore)
                uiManager.ShowRestartCanvas(false);
        }
    }

   


    public void Increment(Score whichScore)
    {
        if (whichScore == Score.AiScore)
        {
            AiScoreTxt.text = (++AiScore).ToString();
        }
        else   
        {
            PlayerScoreTxt.text = (++PlayerScore).ToString();
        }
           
    }

    public void ResetScores()
    {
        AiScore = PlayerScore = 0;
        AiScoreTxt.text = PlayerScoreTxt.text = "0";
    }

    
}

