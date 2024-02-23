using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlow: MonoBehaviour
{
    public GameObject SlowSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameObject ballcontroller = other.gameObject;
            BallController ball = ballcontroller.GetComponent<BallController>();

            if (ball)
            {
                Instantiate(SlowSFX, transform.position, transform.rotation);
                Destroy (gameObject);
                ball.SlowDown();
            }
            
        }
    }

}
