using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
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
            randx = Random.Range(30f, 35f);
            whereToSpawn = new Vector2(randx,transform.position.y);
            //Instantiate(enemy, whereToSpawn, Quaternion.identity);
            GameObject enemy = PoolEnemy.ShareInstance.GetPoolObject();
            if (enemy != null)
            {
                enemy.transform.position = whereToSpawn;
                enemy.transform.rotation = Quaternion.identity;
                enemy.SetActive(true);
                //Enemy2.instance.health +=20;
            }
        }
    }
}
