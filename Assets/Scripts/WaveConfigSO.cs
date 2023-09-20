using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Confing")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 10f;
    public float GetMoveSpeed() {return moveSpeed;}
    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
}