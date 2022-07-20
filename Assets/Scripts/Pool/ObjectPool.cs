using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    private List<GameObject> poolObjects = new List<GameObject>();
    [SerializeField] private int amountPool = 30;
    [SerializeField] private GameObject bullet;

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < amountPool; i++)
        {
            GameObject tmpObj = Instantiate(bullet);
            tmpObj.SetActive(false);
            poolObjects.Add(tmpObj);
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountPool; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                poolObjects[i].SetActive(true);
                return poolObjects[i];
            }
        }

        return null;
    }
}
