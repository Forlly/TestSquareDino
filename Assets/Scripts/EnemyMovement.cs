using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;

    public Vector3 CheckDistanceToPlayer(Transform player)
    {
        Vector3 distance = new Vector3();
        distance = player.position - transform.position;
        return distance;
    }
    
    public void FollowToPlayer(Transform player)
    {
        transform.position =
            Vector3.MoveTowards(transform.position, player.position,
                speed * Time.deltaTime);

    }
}
