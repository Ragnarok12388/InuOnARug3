using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoge : Player
{
    public bool spacekey;
    public Dogelaserbehavior laser;
    // Start is called before the first frame update
    void Start()
    {
        spacekey = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionX, directionY).normalized;
        if (poweredUp == true && Time.timeSinceLevelLoad > Powerend)
        {
            poweredUp = false;
            Star.SetBool("Poweredup", false);
        }
        if (spacekey == true)
        {
            spacekey = Input.GetKeyDown(KeyCode.Space);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacekey = true;
            Dogelaserbehavior LaserInstance = Instantiate(laser, transform.position + new Vector3(0.2f, 0.8f, 0), transform.rotation);
        }
    }
}
