using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private float _speed;

    public Vector3 Postion { get { return transform.position; } }

    private int _currentWaypoint = 0;

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint].transform.position)
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Count;

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].transform.position, _speed * Time.deltaTime);
    }
}
