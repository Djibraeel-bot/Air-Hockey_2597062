using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontroller : paddle
{

    private Boundary AIBoundary;
    public Rigidbody2D AIpaddle;
    struct Boundary
    {
        public float Up, Down, Left, Right;

        public Boundary(float up, float down, float left, float right)
        {
            Up = up; Down = down; Left = left; Right = right;
        }
    }

    public void FixedUpdate()
    {
        if (this.AIpaddle.velocity.y > 0.0f)
        {
            if (this.AIpaddle.position.y > this.transform.position.y)
            {
                rb.AddForce(Vector2.up * this.speed);
            }
            else if (this.AIpaddle.position.y < this.transform.position.y)
            {
                rb.AddForce(Vector2.down * this.speed);

            }
            else
            {
                if (rb.position.y > 0.0f)
                {
                    rb.AddForce(Vector2.down * this.speed);
                }
                else if (this.transform.position.y < 0.0f)
                {
                    rb.AddForce(Vector2.up * this.speed);

                }

            }
        }
        if (this.AIpaddle.velocity.x > 0.0f)
        {
            if (this.AIpaddle.position.x > this.transform.position.x)
            {
                rb.AddForce(Vector2.right * this.speed);
            }
            else if (this.AIpaddle.position.x < this.transform.position.x)
            {
                rb.AddForce(Vector2.left * this.speed);

            }
            else
            {
                if (rb.position.x > 0.0f)
                {
                    rb.AddForce(Vector2.left * this.speed);
                }
                else if (this.transform.position.y < 0.0f)
                {
                    rb.AddForce(Vector2.right * this.speed);

                }

            }
        }
    }
}
