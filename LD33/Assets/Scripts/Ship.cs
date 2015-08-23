using UnityEngine;
using System.Collections;

public class Ship : BoatMovement
{

    void Start()
    {
        //transform.position = NewPoint();
        dest = NewPoint();
    }

    void Update ()
    {
        if (!reversing)
            Move();
        else
            AvoidCollision();


        // Deals with ships going off screen. Players will just think they lost their chance
        if(transform.position.x < (water.transform.position.x - water.bounds.size.x * 0.50f) &&
            transform.position.x > (water.transform.position.x + water.bounds.size.x * 0.50f) &&
            transform.position.y < (water.transform.position.y - water.bounds.size.y * 0.50f) &&
            transform.position.y > (water.transform.position.y + water.bounds.size.y * 0.50f))
        {
            Destroy(gameObject);
        }
	}
}
