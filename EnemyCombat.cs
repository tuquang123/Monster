using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage = 1;
    public void OnTriggerEnter(Collider other)
    {
        ShieldTower Player = other.GetComponent<ShieldTower>();
        if (Player != null)
        {
            Player.TakeDamage(damage);
        }
        Soldie player = other.GetComponent<Soldie>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
