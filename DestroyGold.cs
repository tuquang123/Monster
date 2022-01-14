using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGold : MonoBehaviour
{
	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
			UiManager.instace.gold++;
			UiManager.instace.textGold.text = UiManager.instace.gold.ToString();
		}
	}
}
