using System.Collections;
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
               StopAllCoroutines();
               PlayerControls.Instans.MoveToNextWayPoint();
               break;
            }

            StartCoroutine(LookAtEnemys());
         }
      }

      return false;
   }

   public IEnumerator LookAtEnemys()
   {
      Vector3 middlePoint = Vector3.zero;
      for (int i = 0; i < enemys.Count; i++)
      {
         middlePoint += enemys[i].transform.position;
      }

      middlePoint /= enemys.Count;
      Vector3 targetDirection = middlePoint - PlayerControls.Instans.transform.position;
      Quaternion rotation = Quaternion.LookRotation(targetDirection);
      float time = 0f;
      Quaternion start = PlayerControls.Instans.transform.rotation;
      float speed = 0.15f;
      float step = speed * Time.deltaTime;
      while (time < 1)
      {
         PlayerControls.Instans.transform.rotation = Quaternion.Slerp(start, rotation, time);
         yield return null;
         time += step;
      }
   }
}
