using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prevent2Touch : MonoBehaviour
{
    public bool AiHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "AiPlayer")
        {
            AiHit = true;
        }
        if (collision.gameObject.name == "Player1")
        {
            AiHit = false;
        }
    }
}
