using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public float health = 5;

    public void BeenHit()
    {
        if(health == 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                if(gameObject.GetComponent<BoxCollider2D>())
                {
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
                else if (gameObject.GetComponent<CircleCollider2D>())
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                }

            }
        else if(health == 1)
        {
            LowHealth();
            health = health - 1;
        }
        else
            {
                health = health - 1;
            }
    }

    public void LowHealth()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.64f, 0.0f);
    }

    
}
