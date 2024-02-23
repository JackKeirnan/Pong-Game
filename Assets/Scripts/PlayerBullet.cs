using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent<EnemyController>(out EnemyController enemy))
        {
            Destroy (gameObject);
            StartCoroutine(SlowDownPlayer(enemy));
        }
        else if(collider.gameObject.TryGetComponent<BallController>(out BallController ball))
        {
            Destroy (gameObject);
            ball.SpeedUp();
        }
    }

    IEnumerator SlowDownPlayer(EnemyController paddle)
    {
        paddle.BulletHit();
        yield return new WaitForSeconds(1F);
        
    }
}
