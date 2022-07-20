using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private CharacterAnimatorController animatorHelper;
    private GameController gameController;
    public static PlayerControls Instans;
    private int currentWayPoint = 0;

    private void Start()
    {
        Instans = this;
        gameController = GameController.Instans;
        transform.position = gameController.wayPoints[0].position;
        animatorHelper.ForceActiveAnimationState("Idle");
    }
    

    public void MoveToNextWayPoint()
    {
        for (int i = 0; i < gameController.wayPoints.Length ; i++)
        {
            if (currentWayPoint == gameController.wayPoints.Length - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                transform.position = gameController.wayPoints[0].position;
                currentWayPoint = 0;
                animatorHelper.ForceActiveAnimationState("Run");
                StartCoroutine(Move());
                break;
            }
            if (currentWayPoint == i)
            {
                navMeshAgent.SetDestination(gameController.wayPoints[i + 1].position);
                
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
            yield return null;
        }
        
        animatorHelper.SetAnimationState("Run", false);
        animatorHelper.ForceActiveAnimationState("Idle");

    }
}
