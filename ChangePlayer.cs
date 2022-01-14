using Assets.HeroEditor.Common.ExampleScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ChangePlayer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    public GameObject Money;

    private void Update()
    {
        Changer();
    }
    private void Star()
    {
        player1 = GetComponent<GameObject>();
        player2 = GetComponent<GameObject>();
        player3 = GetComponent<GameObject>();
        player4 = GetComponent<GameObject>();
        player5 = GetComponent<GameObject>();
        Money = GetComponent<GameObject>();

    }
    public void Changer()
    {
        if (CrossPlatformInputManager.GetButtonDown("up"))
        {
            if (UiManager.instace.gold >= 10&& player1.activeSelf)
            {
                player2.SetActive(true);
                player1.SetActive(false);
                UiManager.instace.gold-=10;
                UiManager.instace.textGold.text = UiManager.instace.gold.ToString();
                Combat.instace.damage += 2;
            }
            else if (UiManager.instace.gold >= 20 && player2.activeSelf)
            {
                player3.SetActive(true);
                player2.SetActive(false);
                UiManager.instace.gold -= 20;
                UiManager.instace.textGold.text = UiManager.instace.gold.ToString();
                Combat.instace.damage += 4;
            }
            else if (UiManager.instace.gold >= 30&& player3.activeSelf)
            {
                player4.SetActive(true);
                player3.SetActive(false);
                UiManager.instace.gold -= 30;
                UiManager.instace.textGold.text = UiManager.instace.gold.ToString();
            }
            else if (UiManager.instace.gold >= 40&& player4.activeSelf)
            {
                player5.SetActive(true);
                player4.SetActive(false);
                UiManager.instace.gold -= 40;
                UiManager.instace.textGold.text = UiManager.instace.gold.ToString();

            }
            else
            {
                StartCoroutine(falseObj());
                Money.SetActive(true);
            }
        }
    }
    IEnumerator falseObj()
    {
        yield return new WaitForSeconds(0.6f);
        Money.SetActive(false);
    }
       
}
