using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;

    int waypointIndex = 0; // to keep track of which waypoint we're using from the list

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        if (waypointIndex < waypoints.Count)
        {
            //if there are waypoints left in the list, move the enemy
            var targetPosition = waypoints[waypointIndex].transform.position; //next waypoint we need to go to

            targetPosition.z = 0f;

            var movementThisFrame = moveSpeed * Time.deltaTime; //setting the movement speed frame independent

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            /*
             * MoveTowards() method returns new coordinates every frame to move the object from the current position
             * to the target position at different intervals depending on the speed given via the third parameter.
             */

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
            /* To rest enemy (start moving from the beginning of the path, you would need the following code:
             * waypointIndex = 0;
             */
        }
    }
}
