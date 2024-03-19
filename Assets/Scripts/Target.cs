using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private int _speed;

    private int currentWaypointIndex = 0;

    private void OnCollisionEnter(Collision collision)
    {
        bool isfoundWaypoint = false; 

        for (int i = 0; i < _wayPoints.Length && !isfoundWaypoint; i++)
        {
            if (collision.transform == _wayPoints[i])
            {
                currentWaypointIndex = (i + 1) % _wayPoints.Length;

                isfoundWaypoint = true;
            }
        }
    }

    private void Update()
    {
        Transform targetWaypoint = _wayPoints[currentWaypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, _speed * Time.deltaTime);
    }
}
