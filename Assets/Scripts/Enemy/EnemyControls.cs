using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    [SerializeField] private EnemyHP enemyHp;
    [SerializeField] private int startingHP = 3;
    [SerializeField] private int currentHP = 3;
    
    [SerializeField] private SkinnedMeshRenderer skinnedMesh;
    [SerializeField] private Material dieMaterial;
    
    [SerializeField] private Collider mainCollider;
    [SerializeField] private Collider[] ragdollColliders;

    private void Awake()
    {
        ragdollColliders = GetComponentsInChildren<Collider>();
        DoRagdoll(false);
    }

    public void ReceiveDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            DeleteEnemyFromWayPoint();
        }
        
        enemyHp.UpdateSpriteHP(currentHP,startingHP);
    }

    public void DeleteEnemyFromWayPoint()
    {
        for (int i = 0; i <  GameController.Instans.WayPoits.Length; i++)
        {
            if (GameController.Instans.WayPoits[i].DeleteEnemys(this))
            {
                break;
            }
        }
        StartCoroutine(DoRagdoll(true));
        skinnedMesh.material = dieMaterial;
        enemyHp.UpdateSpriteHP(0,startingHP);
    }

    public IEnumerator DoRagdoll(bool isRagdoll)
    {
        foreach (var col in ragdollColliders)
        {
            col.enabled = isRagdoll;
        }
        
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;
        
        mainCollider.enabled = !isRagdoll;
        yield return new WaitForSeconds(0.3f);
        Destroy(this);
    }
}
