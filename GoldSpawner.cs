using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject enemy;
    float randx;
    Vector2 whereToSpawn;
    public float spawnRate;
    float nextSpawn = 0.0f;
    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randx = Random.Range(-10f, 13f);
            whereToSpawn = new Vector2(randx, transform.position.y);
            //Instantiate(enemy, whereToSpawn, Quaternion.identity);
            GameObject gold = PoolGold.ShareInstance.GetPoolObject();
            if (gold != null)
            {
                gold.transform.position = whereToSpawn;
                gold.transform.rotation = Quaternion.identity;
                gold.SetActive(true);
            }
        }
    }
}
