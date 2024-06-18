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
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionX, directionY).normalized;
        if (poweredUp == true && Time.timeSinceLevelLoad > Powerend)
        {
            poweredUp = false;
            Star.SetBool("Poweredup", false);
        }
    }

    public virtual void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);

        Vector2 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -7.5f, 7.5f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4f, 4f);
        rb.position = clampedPosition;
    }

    public void Power(double time)
    {
        poweredUp = true;
        Star.SetBool("Poweredup", true);
        Powerend = Time.timeSinceLevelLoad + time;
    }
}

