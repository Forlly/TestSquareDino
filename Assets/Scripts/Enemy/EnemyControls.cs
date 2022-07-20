using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private EnemyHP enemyHp;
    [SerializeField] private int startingHP = 3;
    [SerializeField] private int currentHP = 3;

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

    public void ReceiveDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            EnemysController.Instance.DeleteEnemys(this);
            Destroy(gameObject);
        }
        
        enemyHp.UpdateSpriteHP(currentHP,startingHP);
    }
}
