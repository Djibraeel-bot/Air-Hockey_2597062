using UnityEngine;
using System.Collections;

public class AIPlayer : MonoBehaviour
{

    public Transform puck;
    public float speed = 5.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private Vector2 targetPosition;
    private bool isFirstTimeInOpponentsHalf = true;
    private float offsetXFromTarget;
    void FixedUpdate()
    {
        // Calculate the angle and direction of the puck
        Vector2 direction = puck.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;

        // Determine the optimal position for the AI player to move to
        Vector2 targetPosition = puck.position;

        // If the puck is heading towards the AI player's goal, move towards a defensive position
        if (puck.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            targetPosition = new Vector2(0, -3.5f);
        }


        // Move towards the target position
        Vector2 currentPosition = transform.position;
        Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        rb.MovePosition(newPosition);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Avoid hitting the puck after first collision
        if (collision.gameObject.CompareTag("Puck"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
        }
    }
}
