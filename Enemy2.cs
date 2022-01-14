using Assets.HeroEditor.Common.CommonScripts.Springs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
	public int hpAdd = 1;
	public int damage = 1;
	public int health = 5;
	public float Delay;
	public float Timer;

	void Start()
	{
		Timer = Delay;
	}

	void Update()
	{
		Timer -= Time.deltaTime;
		if (Timer <= 0f)
		{
            hpAdd += 1;
			Timer = Delay;
		}
	}
	public virtual void Spring()
	{
		ScaleSpring.Begin(this, 1f, 1.1f, 40, 2);
	}
   public GameObject deathEffect;
    public void TakeDamage(int damage)
	{
		Spring();
		health -= damage;
		if (health <= 0)
		{
			Die();
		}
	}
	public void OnTriggerEnter(Collider other)
	{
        ShieldTower tower = other.GetComponent<ShieldTower>();
        if (tower != null)
        {
            tower.TakeDamage(damage);
            Die();
        }
		Soldie sol = other.GetComponent<Soldie>();
		if (sol != null)
		{
			sol.TakeDamage(damage);
			health--;
		}
	}

	void Die()
	{
		GameObject fx = PoolFx.ShareInstance.GetPoolObject();
		if (fx != null)
		{
			fx.transform.position = transform.position;
			fx.transform.rotation = Quaternion.identity;
			fx.SetActive(true);
		}
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject);
        gameObject.SetActive(false);
		health = 5;
        health += hpAdd;
		UiManager.instace.gold++;
		UiManager.instace.textGold.text = UiManager.instace.gold.ToString();
	}

}