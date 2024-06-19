using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody2D rb;
    public Vector2 playerDirection;
    public int startingLives = 3;
    public int lives;
    public bool poweredUp = false;
    public double Powerend;
    public Animator Star;

    private Vector2 touchStartPos;
    private Vector2 touchCurrentPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        poweredUp = false;
        Star = GetComponent<Animator>();
        lives = startingLives;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        // Reset player direction
        playerDirection = Vector2.zero;

        // Handling keyboard input
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        Vector2 keyboardDirection = new Vector2(directionX, directionY);

        // Handling touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                touchCurrentPos = touch.position;
                Vector2 touchDelta = touchCurrentPos - touchStartPos;
                if (Vector2.Distance(touchCurrentPos, rb.position) > 0.1f)
                    playerDirection = new Vector2(touchDelta.x, touchDelta.y).normalized;
                else
                    playerDirection = Vector2.zero;
            }
        }

        // Handling mouse input
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePosition, rb.position) > 0.1f)
                playerDirection = (mousePosition - rb.position).normalized;
            else
                playerDirection = Vector2.zero;
        }

        // If no touch or mouse input, use keyboard input
        if (playerDirection == Vector2.zero)
        {
            playerDirection = keyboardDirection.normalized;
        }

        if (poweredUp && Time.timeSinceLevelLoad > Powerend)
        {
            poweredUp = false;
            Star.SetBool("Poweredup", false);
        }
    }

    public virtual void FixedUpdate()
    {
        // Calculate movement direction
        Vector2 movement = playerDirection.normalized * playerSpeed * Time.fixedDeltaTime;

        // Calculate target position
        Vector2 targetPosition = rb.position + movement;

        // Move towards the target position
        rb.MovePosition(targetPosition); 
    }


    public void Power(double time)
    {
        poweredUp = true;
        Star.SetBool("Poweredup", true);
        Powerend = Time.timeSinceLevelLoad + time;
    }
}
