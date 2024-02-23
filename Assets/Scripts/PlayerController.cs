using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    //speed of player
    public float speed = 10;
    //bounds of player
    public float topBound = 4.5F;
    public float bottomBound = -4.5F;
    
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        //pauses or plays game when player hits p
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get player input and set speed
        float movementSpeedY = speed * Input.GetAxis("Vertical")
        * Time.deltaTime;
        transform.Translate(0, movementSpeedY, 0);
        //set bounds of player
        if (transform.position.y > topBound)
        {
            transform.position = new Vector3(transform.position.x,
            topBound, 0);
        }
        else if (transform.position.y < bottomBound)
        {
            transform.position = new Vector3(transform.position.x,
            bottomBound, 0);
        }
    }

    public void BulletHit()
    {
        speed = speed - 1;   
    }

}