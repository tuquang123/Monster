using Assets.HeroEditor.Common.CommonScripts.Springs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldie : MonoBehaviour
{
	public int health = 5;
	public Animator anm;

	public virtual void Spring()
	{
		ScaleSpring.Begin(this, 1f, 1.1f, 40, 2);
	}
	public GameObject deathEffect;
	public void TakeDamage(int damage)
	{
		Spring();
		//StartCoroutine(DamageAnimation());
		health -= damage;
		if (health <= 0)
		{
			Die();
		}
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			anm.SetTrigger("attack");
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		//gameObject.SetActive(false);
		//health = 5;
	}

}