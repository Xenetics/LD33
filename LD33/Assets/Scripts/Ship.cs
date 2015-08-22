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
        if (!colliding)
            Move();
        else
            AvoidCollision();
	}
}
