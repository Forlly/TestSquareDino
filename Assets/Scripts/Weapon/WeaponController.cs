using System;
using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public Weapon weapon;
    public GameObject bullet;
    public Transform spawnBulletPos;
    [SerializeField] private PlayerControls player;
    

    public void Fire(Vector3 endPoint, Action calback = null)
    {
        StartCoroutine(Shot(endPoint, calback));
    }
    
    private IEnumerator Shot(Vector3 endPoint, Action calback = null)
    {
        Vector3 startPoint = spawnBulletPos.position;

        GameObject _bullet = ObjectPool.Instance.GetPooledObject();
        if (_bullet != null)
        {
            _bullet.transform.position = startPoint;
        }

        float wspeed = (weapon.speed * Time.deltaTime) / Vector3.Distance(startPoint,endPoint);
        float progressFly = 0f;
        float lifeTime = weapon.lifeTime;
        
        float currentTime = 0f;
        while (true)
        {
            yield return null;
            currentTime += Time.fixedDeltaTime;
            
            progressFly += wspeed;
            _bullet.transform.position = Vector3.Lerp(startPoint, endPoint, progressFly);
            
            
            if (currentTime >= lifeTime || progressFly >= 1)
            {
                _bullet.SetActive(false);
                calback?.Invoke();
                yield break;
            }
        }
    }


    public void MakeDamage( EnemyMovement enemy)
    {
        enemy.ReceiveDamage(weapon.Damage);
    }
}
