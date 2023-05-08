using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public puckMovement puck; 
    
        private int p1Score;
        private int pcScore;
    void Start()
    {
        
    }
    public void PlayerScore() 
    {
        p1Score++;
         Debug.Log(p1Score);

        this.puck.ResetPosition();
    }

    public void ComputerScore()
    {
        pcScore++;
        Debug.Log( pcScore);

        this.puck.ResetPosition();
    }
   
    void Update()
    {
        
    }
}
