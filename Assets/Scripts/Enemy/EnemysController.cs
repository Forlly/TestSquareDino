using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemysController : MonoBehaviour
{
    [SerializeField] public List<EnemyControls> enemys;
    public static EnemysController Instance;
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

    }

    
}
