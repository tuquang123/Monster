using Assets.HeroEditor.Common.ExampleScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerAttack : MonoBehaviour
{
    public AttackingExample attacking;
    public void OnTriggerEnter(Collider other)
    {
        Enemy2 enemy = other.GetComponent<Enemy2>();
        if (enemy != null)
        {
            attacking.Character.Slash();

        }
        Boss boss = other.GetComponent<Boss>();
        if (boss != null)
        {
            attacking.Character.Slash();
        }
    }
}
