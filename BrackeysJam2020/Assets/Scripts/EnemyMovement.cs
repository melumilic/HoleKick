using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private Transform[] _waypoints;
    private int _followPoint = 0;
    private bool _pointReached = false;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        _waypoints = WaypointFollow.points;
        dir = (_waypoints[_followPoint].position - transform.position).normalized;
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((_waypoints[_followPoint].position - transform.position).magnitude < .2)
        {
            Debug.Log("collided");
            _followPoint++;
            dir = (_waypoints[_followPoint].position - transform.position).normalized;
        }
        transform.Translate(dir * _speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "waypoint")
        {
            Debug.Log("collided");
            _followPoint++;
            dir = (_waypoints[_followPoint].position - transform.position).normalized;
        }
    }
}
