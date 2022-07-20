using System.Collections.Generic;
using UnityEngine;

public class WayPoit : MonoBehaviour
{
   [SerializeField] public Transform point;
   [SerializeField] public List<EnemyControls> enemys;
   
   public bool DeleteEnemys(EnemyControls enemy)
   {
      for (int i = 0; i < enemys.Count; i++)
      {
         if (enemys[i] == enemy)
         {
            enemys.Remove(enemys[i]);
            if (enemys.Count == 0)
            {
               PlayerControls.Instans.MoveToNextWayPoint();
            }
         }
      }

      return false;
   }
}
