using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private CharacterAnimatorController animatorHelper;
    public static PlayerControls Instans;
    private int currentWayPoint = 0;

    public bool killedEnemy = false;


    private void Awake()
    {
        Instans = this;
        transform.position = wayPoints[0].position;
        animatorHelper.ForceActiveAnimationState("Idle");
    }
    

    public void MoveToNextWayPoint()
    {
        for (int i = 0; i < wayPoints.Length - 1; i++)
        {
            if (currentWayPoint == wayPoints.Length - 1)
            {
                transform.position = wayPoints[0].position;
                currentWayPoint = 0;
                animatorHelper.ForceActiveAnimationState("Run");
                StartCoroutine(Move());
                break;
            }
            if (currentWayPoint == i)
            {
                navMeshAgent.SetDestination(wayPoints[i + 1].position);
                
                currentWayPoint++;
                animatorHelper.ForceActiveAnimationState("Run");
                StartCoroutine(Move());
                break;
            }
        }
    }


    private IEnumerator Move()
    {
        Vector3 prePos = transform.position;
        yield return new WaitForSeconds(0.05f);

        while (transform.position != prePos)
        {
            prePos = transform.position;
            yield return new WaitForFixedUpdate();
        }
        
        animatorHelper.SetAnimationState("Run", false);
        animatorHelper.ForceActiveAnimationState("Idle");

    }
}
