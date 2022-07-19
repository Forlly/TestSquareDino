using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] wayPoints;
    public static PlayerControls Instans;
    private int currentWayPoint = 0;

    public bool killedEnemy = false;


    private void Awake()
    {
        Instans = this;
        transform.position = wayPoints[0].position;
    }
    

    public void MoveToNextWayPoint(Vector3 position)
    {
        for (int i = 0; i < wayPoints.Length - 1; i++)
        {
            if (currentWayPoint == i)
            {
                Debug.Log(wayPoints[i + 1].position);
                navMeshAgent.SetDestination(wayPoints[i + 1].position);
                currentWayPoint++;
                break;
            }
            else if (currentWayPoint == wayPoints.Length - 1)
            {
                transform.position = wayPoints[0].position;
                currentWayPoint = 0;
                break;
            }
        }
    }
}
