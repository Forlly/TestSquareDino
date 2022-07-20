using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemysController : MonoBehaviour
{
    [SerializeField] public List<EnemyControls> enemys;
    public static EnemysController Instance;
    private Vector3 distance;
    private int countNearEnemys;
    [SerializeField] private Vector3 triggerDistance;

    private void Awake()
    {
        Instance = this;
    }

    public void DeleteEnemys(EnemyControls enemy)
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == enemy)
            {
                enemys.Remove(enemys[i]);
            }
        }
        
        CheckDistanceBetweenEnemysPlayer();
    }

    public void CheckDistanceBetweenEnemysPlayer()
    {
        countNearEnemys = 0;
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i])
            {
                distance = enemys[i].CheckDistanceToPlayer(PlayerControls.Instans.transform);
                if (Mathf.Abs(distance.z) <= Mathf.Abs(triggerDistance.z))
                {
                    //enemys[i].FollowToPlayer(PlayerControls.Instans.transform);
                    Debug.Log(enemys[i].name);
                    countNearEnemys++;
                }
            }
        }

        if (countNearEnemys == 0)
        {
            PlayerControls.Instans.MoveToNextWayPoint();
        }
        
        Debug.Log(countNearEnemys);
    }
}
