using Assets.FantasyMonsters.Scripts.Tweens;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldTower : MonoBehaviour
{
	public GameObject shield;
	public int health = 10;
	public Text textHp;
	public GameObject deathEffect;
	public int damage = 1;
	private void Start()
	{
		textHp.text = health.ToString();
	}
	public virtual void Spring()
	{
		ScaleSpring.Begin(this, 1f, 1.1f, 40, 2);
	}
	public void OnTriggerEnter(Collider other)
	{
		Enemy2 enemy = other.GetComponent<Enemy2>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
			//Die();
		}
	}
    public virtual void TakeDamage(int damage)
	{
		Spring();
		health -= damage;
		textHp.text = health.ToString();

		if (health <= 0)
		{
			Die();
			//shield.SetActive(false);
		}
	}
	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
