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
        transform.position = gameController.WayPoits[0].point.position;
        animatorHelper.ForceActiveAnimationState("Idle");
    }
    

    public void MoveToNextWayPoint()
    {
        for (int i = 0; i < gameController.WayPoits.Length ; i++)
        {
            if (currentWayPoint == gameController.WayPoits.Length - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                currentWayPoint = 0;
                StartCoroutine(Move());
                break;
            }
            if (currentWayPoint == i)
            {
                animatorHelper.ForceActiveAnimationState("Run");
                navMeshAgent.SetDestination(gameController.WayPoits[i + 1].point.position);
                currentWayPoint++;
                
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
