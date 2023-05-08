using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newAIcontroller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D goal;
    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    private Vector2 startingPosition;

    public Rigidbody2D Puck;

    public Transform AIBoundaryHolder;
    private Boundary aiBoundary;

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;
    private Rigidbody2D AIGoal;

    public Transform playerBoundaryHolder;
    private Boundary playerBoundary;

    private Vector2 targetPosition;
    private bool isFirstTimeInOpponentsHalf = true;
    private float offsetXFromTarget;
    private Vector2 safetypos;
    [SerializeField]
    public Prevent2Touch prevent2Touch;  //you hid this shit
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;

        aiBoundary = new Boundary(AIBoundaryHolder.GetChild(0).position.y,
                                      AIBoundaryHolder.GetChild(1).position.y,
                                      AIBoundaryHolder.GetChild(2).position.x,
                                      AIBoundaryHolder.GetChild(3).position.x);

        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                                      PuckBoundaryHolder.GetChild(1).position.y,
                                      PuckBoundaryHolder.GetChild(2).position.x,
                                      PuckBoundaryHolder.GetChild(3).position.x);
        safetypos = new Vector2(3.5f, -6.9f);
    }
    private void FixedUpdate()
    {
        if (!PuckStuff.WasGoal)
        {



            float movementSpeed;
            Vector2 midpoint = (goal.position - Puck.position) / 2;
            RaycastHit2D hit = Physics2D.Raycast(Puck.position, goal.position - Puck.position, Mathf.Infinity, LayerMask.GetMask("Paddles"));
            targetPosition = goal.position - midpoint;
            if (hit)
            {
                if (hit.collider == GetComponent<CircleCollider2D>())
                {
                    targetPosition = Puck.position;
                }
            }
            movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.9f); //you just changed this from 9
            if (Puck.position.y < puckBoundary.Down)
            {
                if (isFirstTimeInOpponentsHalf)
                {
                    isFirstTimeInOpponentsHalf = false;
                    offsetXFromTarget = Random.Range(-1f, 1f);
                }
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + offsetXFromTarget, playerBoundary.Left,
                                              playerBoundary.Right), startingPosition.y);  //this line was hidden
            }
            else
            {
                isFirstTimeInOpponentsHalf = true;

                movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left,
                                                 playerBoundary.Right),
                                                 Mathf.Clamp(Puck.position.y, playerBoundary.Down,
                                                 playerBoundary.Up));
            }
            Vector2 clampedPosition = new Vector2(Mathf.Clamp(targetPosition.x, aiBoundary.Left, aiBoundary.Right),
                Mathf.Clamp(targetPosition.y, aiBoundary.Down, aiBoundary.Up));
            //Debug.Log("The clamped position is " + clampedPosition);
            targetPosition = clampedPosition;
            //Debug.Log(targetPosition);
            if (Puck.position.x >= 0)
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));
            }
            else
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, startingPosition, movementSpeed * Time.fixedDeltaTime));
            }
            if (prevent2Touch.AiHit && Puck.position.x >= 0)
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, safetypos, movementSpeed * Time.fixedDeltaTime));
            }

        }
        
    }
public void ResetPostion()
{
    rb.position = startingPosition;
}
}
struct Boundary
{
    public float Up, Down, Left, Right;

    public Boundary(float up, float down, float left, float right)
    {
        Up = up; Down = down; Left = left; Right = right;
    }

    internal bool Contains(Vector2 position)
    {
        throw new System.NotImplementedException();
    }
}

