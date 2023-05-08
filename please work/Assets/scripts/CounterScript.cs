using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CounterScript : MonoBehaviour
{
    public GameObject UiCanvasGame;
    public TextMeshProUGUI CountdownText;
    public PuckStuff puckScript;
    public playerController playerMovement;
    public AiScript aiScript;

    public float timeLeft = 5f;// Start is called before the first frame update
    void Start()
    {
        UiCanvasGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        {
            timeLeft -= Time.deltaTime;
            CountdownText.text = timeLeft.ToString("0");

            if (timeLeft > 0)
            {
                puckScript.enabled = false;
                aiScript.enabled = false;
                playerMovement.enabled = false;
            }

            else
            {
                puckScript.enabled = true;
                aiScript.enabled = true;
                playerMovement.enabled = true;
            }

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                CountdownText.gameObject.SetActive(true);
                UiCanvasGame.gameObject.SetActive(true);
            }
            
            
        }
    }
}
//use a coroutine for to link it and make ui