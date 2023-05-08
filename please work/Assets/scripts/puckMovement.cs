using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puckMovement : MonoBehaviour
{
    public float speed = 800.0f;
    private Rigidbody2D rb;
    private Vector2 direction; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Start()
    {
        ResetPosition();
    }
    public void ResetPosition()
    {
        rb.position = Vector3.zero;
        rb.velocity = Vector3.zero;

        //BallSpawnForce();
    }
   // private void BallSpawnForce()
   // {
        //float x = Random.value < 0.5f ? -1.0f : 1.0f;
      // float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

      // Vector2 direction = new Vector2(x, y);
        //rb.AddForce( direction* this.speed);
    //}
    private void FixedUpdate()
    {
        if (direction.sqrMagnitude != 0) 
        {
            rb.AddForce(direction * speed);
        }
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }
    
    
   
   
}
