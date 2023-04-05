using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;
    Stats stats;
    Direction dir;
    enum Direction
    {
        FORWARD = 1,
        BACKWARD = -1
    }
    
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        dir = Direction.FORWARD;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {
            if (currentWaypointIndex >= waypoints.Length - 1) dir = Direction.BACKWARD;
            else if (currentWaypointIndex == 0) dir = Direction.FORWARD;
            currentWaypointIndex += (int)dir * 1;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, stats.getSpeed()*Time.deltaTime);
    }
}
