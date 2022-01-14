using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public static Combat instace;
    public int damage = 1;
    private void Awake()
    {
        instace = this;
    }
    public void OnTriggerEnter(Collider other)
    {
        Enemy2 enemy = other.GetComponent<Enemy2>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Boss boss = other.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
    }
}
