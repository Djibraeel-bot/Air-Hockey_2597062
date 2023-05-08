using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncy : MonoBehaviour
{
    public float bounceStrength;

    private Rigidbody2D rb;
   
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        bouncy puck = collision.gameObject.GetComponent<bouncy>();
        if (puck != null) 
        {
            Vector2 normal = collision.GetContact(0).normal;
            puck.AddForce(normal * this.bounceStrength);
        }
    }
    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
