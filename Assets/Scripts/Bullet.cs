using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            Destroy (gameObject);
            StartCoroutine(SlowDownPlayer(player));
        }
        else if(collider.gameObject.TryGetComponent<BallController>(out BallController ball))
        {
            Destroy (gameObject);
            ball.SpeedUp();
        }
    }

    IEnumerator SlowDownPlayer(PlayerController paddle)
    {
        paddle.BulletHit();
        yield return new WaitForSeconds(1F);
        
    }
}
