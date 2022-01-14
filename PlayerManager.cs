using Assets.HeroEditor.Common.EditorScripts;
using Assets.HeroEditor.Common.ExampleScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SaiMono
{
    public static PlayerManager instance;
    public HeroCtrl currentHero;
    public PlayerAttacking playerAttacking;
    public PlayerMovement playerMovement;
    public BowExample bowExample;

    private void Awake()
    {
        PlayerManager.instance = this;
    }
    private void Start()
    {
        //loadPlayer();
        LoadPlayers();
    }
    private void Reset()
    {
        this.LoadComponents();
    }
    public virtual bool ChoosePlayer(string chooseClass)
    {
        string profileClass;
        foreach(HeroCtrl heroCtrl in PlayerHodle.instance.heroCtrls)
        {
            profileClass = heroCtrl.heroProfile.HeroClass();
            if(profileClass == chooseClass)
            {
                this.SetPlayerCtrl(heroCtrl.gameObject);
                return true;
            }
        }
        return false;
    }

    protected override void LoadComponents()
    {
        this.LoadPlayerComponents();
        
    }
    private void LoadPlayerComponents()
    {
        if (playerAttacking != null) return;
        playerAttacking = transform.GetComponentInChildren<PlayerAttacking>();
        playerMovement = transform.GetComponentInChildren<PlayerMovement>();
        bowExample = transform.GetComponentInChildren<BowExample>();
    }
    protected virtual void LoadPlayers()
    {
        GameObject hero;
        Vector3 vector3 = transform.position;
        vector3.x -= 7;
        foreach (HeroManager heroManager in HeroManagers.instance.heroManagers)
        {
            vector3.x += 3;
            hero = heroManager.GetHero();
            hero.transform.position = vector3;
            hero.transform.parent = PlayerHodle.instance.transform;
            HeroCtrl heroCtrl = hero.GetComponent<HeroCtrl>();
            PlayerHodle.instance.heroCtrls.Add(heroCtrl);

           SetPlayerCtrl(hero);
        }
    }
    public void SetPlayerCtrl(GameObject obj)
    {
       
        this.currentHero = obj.GetComponent<HeroCtrl>();
        this.playerAttacking.character = this.currentHero.character;
        this.playerAttacking.Firearm = currentHero.firearm;
        playerAttacking.ArmL = currentHero.armL;
        playerAttacking.ArmR = currentHero.armR;

        this.playerMovement.Character = currentHero.character;
        this.playerMovement.Controller = currentHero.CharacterCtrl;
    }
}
