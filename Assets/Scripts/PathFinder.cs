using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (wayPointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
                wayPointIndex++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
