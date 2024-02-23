using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    public GameObject SpeedSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameObject ballcontroller = other.gameObject;
            BallController ball = ballcontroller.GetComponent<BallController>();

            if (ball)
            {
                Destroy(gameObject);
                ball.SpeedUp();
                Instantiate(SpeedSFX, transform.position, transform.rotation);
            }
            
        }
    }


}
