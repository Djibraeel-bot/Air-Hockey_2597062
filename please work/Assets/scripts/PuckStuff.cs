using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckStuff : MonoBehaviour
{
    public Scoring ScoringInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;
    public float MaxSpeed;
    int PlayerScore = 0;
    int AiScore = 0;
    bool player1HasHitPuck = false;
    bool aiPlayerHasHitPuck = false;
    public CounterScript cs_counterScript;
    public GameObject go_counterScript;

  void Start()
    {
        cs_counterScript = go_counterScript.GetComponent<CounterScript>();
        // cs_counterScript.currentTime
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }
    public void CenterPuck()
    {
        rb.position = new Vector2(0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "AIGoal")
            {
                ScoringInstance.Increment(Scoring.Score.PlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoringInstance.Increment(Scoring.Score.AiScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }
        }
    }
    private IEnumerator ResetPuck() 
    {
        yield return new WaitForSecondsRealtime(3);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0f, 0f);
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }
   

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            if( player1HasHitPuck && !aiPlayerHasHitPuck) 
            {
                PlayerScore--;
            }
            else
            {
                player1HasHitPuck = true;
                aiPlayerHasHitPuck = false;
            }
        }
        else if (collision.gameObject.CompareTag("AiPlayer"))
        {
            if (aiPlayerHasHitPuck && !player1HasHitPuck)
            {
                AiScore--;
            }
            else
            {
                
                aiPlayerHasHitPuck = true;
                player1HasHitPuck = false;
            }
        }
       
    }
    
    
   
    
        
    }


