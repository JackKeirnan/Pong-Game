using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoundController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroys gameobject if its tag is Ball
        if (other.gameObject.tag == "Ball")
        {
            //Destroy(other.gameObject);
        }

    }
}