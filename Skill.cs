using Assets.HeroEditor.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Skill : MonoBehaviour
{
    [Header("Skill1")]
    public Image skill;
    public float cowndown1 = 40;
    bool isCownDown = false;

    [Header("Skill2")]
    public Image skill_2;
    public float cowndown2 = 90;
    bool isCownDown2 = false;


    public float time = 10f;
    public Character character;

    public GameObject skill1;
    public GameObject skill2;
    private void Start()
    {
        skill.fillAmount = 0;
        skill_2.fillAmount = 0f;
    }
    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("skill1")&& isCownDown == false)
        {
            isCownDown = true;
            skill.fillAmount = 1;
            character.Animator.SetTrigger("skill1");
            Skill1();
        }
        if (isCownDown)
        {
            skill.fillAmount -= 1 / cowndown1 * Time.deltaTime;
            if(skill.fillAmount <= 0)
            {
                skill.fillAmount = 0;
                isCownDown = false;
            }
        }

        if (CrossPlatformInputManager.GetButtonDown("skill2") && isCownDown2 == false)
        {
            isCownDown2 = true;
            skill_2.fillAmount = 1;
            character.Animator.SetTrigger("skill2");
            Skill2();
        }
        if (isCownDown2)
        {
            skill_2.fillAmount -= 1 / cowndown2 * Time.deltaTime;
            if (skill_2.fillAmount <= 0)
            {
                skill_2.fillAmount = 0;
                isCownDown2 = false;
            }
        }
    }
    public void Skill1()
    {
        skill1.SetActive(true);
        StartCoroutine(Skill1Co());
    }
    IEnumerator Skill1Co()
    {
        yield return new WaitForSeconds(time);
        skill1.SetActive(false);
    }
    public void Skill2()
    {
        Instantiate(skill2);
    }
}
