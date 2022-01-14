using Assets.HeroEditor.Common.CharacterScripts;
using Assets.HeroEditor.Common.CharacterScripts.Firearms;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCtrl : SaiMono
{
    //public string charName;
    public Character character;
    public CharacterController CharacterCtrl;
    public Firearm firearm;
    public FirearmFire firearmFire;
    public Transform armL;
    public Transform armR;
    public HeroProfile heroProfile;

    protected override void LoadComponents()
    {
        this.loadCharacter();
        this.loadCharCtrl();
        this.LoadCharBodyParts();
        this.LoadHeroProFile();
    }

    private void LoadHeroProFile()
    {
        if (this.heroProfile != null) return;
        this.heroProfile = GetComponent<HeroProfile>();
    }

    private void LoadCharBodyParts()
    {
        if (firearm != null) return;

        Transform animation = transform.Find("Animation");
        Transform body = animation.Find("Body");
        Transform upper = body.Find("Upper");
        Transform armR1 = upper.Find("ArmR[1]");
        Transform forearmR = armR1.Find("ForearmR");
        Transform randR = forearmR.Find("HandR");
        Transform tranFirearm = randR.Find("Firearm");

        armL = upper.Find("ArmL");
        armR = armR1;
        firearm = tranFirearm.GetComponent<Firearm>();

        this.firearmFire = this.firearm.transform.GetComponent<FirearmFire>();
        this.firearmFire.CreateBullets = true;

    }

    private void loadCharCtrl()
    {
        if (CharacterCtrl != null) return;
        CharacterCtrl = GetComponent<CharacterController>();
        if (CharacterCtrl == null) CharacterCtrl = gameObject.AddComponent<CharacterController>();

        CharacterCtrl.center = new Vector3(0, 1.125f);
        CharacterCtrl.height = 2.5f;
        CharacterCtrl.radius = 0.75f;

        CharacterCtrl.minMoveDistance = 0;
    }

    private void loadCharacter()
    {
        if (this.character != null) return;
        this.character = GetComponent<Character>();
    }
}
