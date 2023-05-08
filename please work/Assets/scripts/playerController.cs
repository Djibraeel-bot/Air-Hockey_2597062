using UnityEngine;

public class playerController : MonoBehaviour
{

    bool wasJustClicked = true;
    bool canMove;
    

    Rigidbody2D rb;
    Vector2 startingPosition;

    public Transform BoundaryHolder;

    Boundary playerBoundary;
    Collider2D playerCollider;
    struct Boundary
    {
        public float Up, Down, Left, Right;

        public Boundary(float up, float down, float left, float right)
        {
            Up = up; Down = down; Left = left; Right = right;
        }
    }

    // Use this for initialization
     private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y,
                                      BoundaryHolder.GetChild(1).position.y,
                                      BoundaryHolder.GetChild(2).position.x,
                                      BoundaryHolder.GetChild(3).position.x);

        playerCollider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;
                
                if( playerCollider.OverlapPoint(mousePos)) 
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left,
                                                                  playerBoundary.Right),
                                                      Mathf.Clamp(mousePos.y, playerBoundary.Down,
                                                                  playerBoundary.Up));
                rb.MovePosition(clampedMousePos);
            }
        }
        else
        {
            wasJustClicked = true;
        }
    }
    public void ResetPosition()
    {
        rb.position = startingPosition;
    }
}
