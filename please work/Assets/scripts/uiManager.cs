using UnityEngine;
using TMPro;
public class uiManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject UiCanvasGame;
    public GameObject UiCanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LoseTxt;

    [Header("Other")]
    public Scoring scoreScript;
    public PuckStuff puckScript;
    public playerController playerMovement;
    public AiScript aiScript;
    public CounterScript countdownScript;
    


    public void ShowRestartCanvas(bool aiWon)
    {
        Time.timeScale = 1;
        UiCanvasGame.SetActive(false);
        UiCanvasRestart.SetActive(true);

        if (aiWon)
        {
            WinTxt.SetActive(false);
            LoseTxt.SetActive(true);
        }
        else
        {
            WinTxt.SetActive(true);
            LoseTxt.SetActive(false);
        }
    }
    
     public void RestartGame(bool aiLose)
    {
        Time.timeScale = 1;

        UiCanvasGame.SetActive(true);
        UiCanvasRestart.SetActive(false);

        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPosition();
        aiScript.ResetPosition();
    }
}
