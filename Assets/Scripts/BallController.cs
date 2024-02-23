using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public GameObject hitSFX;

    public float startspeed;
    public float extraspeed;
    public float maxextraspeed;
    public float powerSpeed;

    private int hitcounter = 0;

    private Rigidbody2D rig2D;
    private Vector2 spawnDir;


    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    public IEnumerator Launch()
    {
        hitcounter = 0;
        yield return new WaitForSeconds(1);
        spawnDir = new Vector2(1, 0);
        moveBall(spawnDir);
    }

    public void moveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballspeed = startspeed + hitcounter * extraspeed;

        rig2D.velocity = direction * ballspeed;
    }

    public void IncreaseHitCounter()
    {
        if (hitcounter * extraspeed < maxextraspeed)
        {
            hitcounter++;
        }
    }

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 paddlePosition = collision.transform.position;
        float paddleHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Player")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - paddlePosition.y) / paddleHeight;

        IncreaseHitCounter();
        moveBall(new Vector2(positionX, positionY));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            Bounce(collision);
        }
        else if(collision.gameObject.name == "RightBound")
        {
            GameController.instance.EnemyScore();
            Object.Destroy(gameObject);   
        }
        else if(collision.gameObject.name == "LeftBound")
        {
            GameController.instance.PlayerScore();
            Object.Destroy(gameObject); 
        }

        else if (collision.gameObject.tag == "Wall")
        {
            if(collision.gameObject.TryGetComponent<WallController>(out WallController wall))
            {
                wall.BeenHit();
            }
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }

    public void SpeedUp()
    {
        extraspeed = extraspeed + 1;
        rig2D.velocity = rig2D.velocity*(float)1.05;
    }

    public void SlowDown()
    {
        extraspeed = extraspeed - 1;
        rig2D.velocity = rig2D.velocity*(float)0.95;
    }
}