using UnityEngine;
using System.Collections;

public abstract class BoatMovement : MonoBehaviour
{
    public float maxSpd;
    public float minSpd;
    public float moveSpd;
    public float turnSpd;
    public Vector2 dest;
    public Renderer water;
    public GameObject sprite;
    public GameObject direction;

    public bool colliding;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(dest, 1);
    }

    public void Move()
    {
        // Move in a forwars direction
        transform.position = Vector2.Lerp(transform.position, direction.transform.position, moveSpd * Time.deltaTime);

        AngleCorrection();

        if(Vector2.Distance(transform.position, dest) < 5)
        {
            dest = NewPoint();
        }
        moveSpd = AdjustSpeed();
    }

    public void AvoidCollision()
    {
        AngleCorrection();
    }

    public Vector2 NewPoint()
    {
        Vector2 newPoint = Vector2.zero;
        newPoint.x = Random.Range(water.transform.position.x - (water.bounds.size.x * 0.5f), water.transform.position.x + (water.bounds.size.x * 0.5f));
        newPoint.y = Random.Range(water.transform.position.y - (water.bounds.size.y * 0.5f), water.transform.position.y + (water.bounds.size.y * 0.5f));

        return newPoint;
    }

    public void AngleCorrection()
    {
        // Angle correction
        float desiredAngle = Mathf.Atan2(dest.y - transform.position.y, dest.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion desiredRot = Quaternion.Euler(0, 0, desiredAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot, turnSpd);
    }

    public float AdjustSpeed()
    {
        float newSpd = 1;

        float screenPercent = Vector3.Distance(transform.position, dest) / water.bounds.size.x;

        newSpd = maxSpd * screenPercent;

        if (newSpd < minSpd)
            newSpd = minSpd;

        return newSpd;
    }

    void OnCollisionEnter(Collision other)
    {
        colliding = true;
    }

    void OnCollisionExit(Collision other)
    {
        colliding = false;
    }
}
