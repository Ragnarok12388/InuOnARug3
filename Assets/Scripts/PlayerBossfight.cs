using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossfight : Player
{
    public override void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > 20.0f)
        {
            rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
        }
    }
}
