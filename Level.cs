using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	public float Delay = 5f;
	public float Timer = 0f;

	void Start()
	{
		Timer = Delay;
	}

	void Update()
	{
		Timer -= Time.deltaTime;
		if (Timer <= 0f)
		{
			Enemy2 enemy = GetComponent<Enemy2>();
			enemy.hpAdd += 10;
			Timer = Delay;
		}
	}
}
