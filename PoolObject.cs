using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public static PoolObject ShareInstance;
    public List<GameObject> poolObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake()
    {
        ShareInstance = this;
    }
    private void Start()
    {
        poolObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            poolObjects.Add(tmp);
        }

    }
    public GameObject GetPoolObject()
    {
        for(int i = 0;i< amountToPool; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }
}
