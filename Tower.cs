using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
	public int health = 100;
	public Text textHp;
	public GameObject deathEffect;

    private void Start()
    {
		textHp.text = health.ToString();
    }
    public void TakeDamage(int damage)
	{
		health -= damage;
		textHp.text = health.ToString();

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
