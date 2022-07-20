using UnityEngine;

public class EnemysController : MonoBehaviour
{
    [SerializeField] private EnemyMovement[] enemys;
    private Vector3 distance;
    [SerializeField] private Vector3 triggerDistance;

    void Update()
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemys[i])
            {
                distance = enemys[i].CheckDistanceToPlayer(PlayerControls.Instans.transform);
                if (Mathf.Abs(distance.z) <= Mathf.Abs(triggerDistance.z))
                    enemys[i].FollowToPlayer(PlayerControls.Instans.transform);
            }
        }
    }
}
