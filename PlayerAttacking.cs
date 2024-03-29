using Assets.HeroEditor.Common.CharacterScripts;
using Assets.HeroEditor.Common.CharacterScripts.Firearms;
using Assets.HeroEditor.Common.CharacterScripts.Firearms.Enums;
using Assets.HeroEditor.Common.ExampleScripts;
using HeroEditor.Common.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    //public AudioSource att;
    public Character character;
    public BowExample BowExample;
    public Firearm Firearm;
    public Transform ArmL;
    public Transform ArmR;
    public KeyCode FireButton = KeyCode.Mouse1;
    
    public KeyCode ReloadButton = KeyCode.R; 
    [Header("Check to disable arm auto rotation.")]
    public bool FixedArm;
    public FirearmFire firearmFire;

    public void Start()
    {
        if ((character.WeaponType == WeaponType.Firearms1H || character.WeaponType == WeaponType.Firearms2H) && Firearm.Params.Type == FirearmType.Unknown)
        {
            throw new Exception("Firearm params not set.");
        }
    }

    public void Update()
    {
        character.GetReady();
        if (character.Animator.GetInteger("State") >= (int)CharacterState.DeathB) return;

        switch (character.WeaponType)
        {
            case WeaponType.Melee1H:
            case WeaponType.Melee2H:
            case WeaponType.MeleePaired:
                if (Input.GetKeyDown(FireButton))
                {
                    character.Slash();
                    //AudioAttack();
                }
                break;
            case WeaponType.Bow:
                BowExample.ChargeButtonDown = Input.GetKeyDown(FireButton);
                BowExample.ChargeButtonUp = Input.GetKeyUp(FireButton);
                break;
            case WeaponType.Firearms1H:
            case WeaponType.Firearms2H:
                //firearmFire.Auto();
                Firearm.Fire.FireButtonDown = Input.GetKeyDown(FireButton);
                Firearm.Fire.FireButtonPressed = Input.GetKey(FireButton);
                Firearm.Fire.FireButtonUp = Input.GetKeyUp(FireButton);
                Firearm.Reload.ReloadButtonDown = Input.GetKeyDown(ReloadButton);
                break;
            case WeaponType.Supplies:
                if (Input.GetKeyDown(FireButton))
                {
                    character.Animator.Play(Time.frameCount % 2 == 0 ? "UseSupply" : "ThrowSupply", 0); // Play animation randomly.
                }
                break;
        }

        if (Input.GetKeyDown(FireButton))
        {
            character.GetReady();
        }
    }
    
    public void Fire()
    {
        firearmFire.Auto();
    }
    /// <summary>
    /// Called each frame update, weapon to mouse rotation example.
    /// </summary>
    public void LateUpdate()
    {
        firearmFire.Auto();
        switch (character.GetState())
        {
            case CharacterState.DeathB:
            case CharacterState.DeathF:
                return;
        }

        Transform arm;
        Transform weapon;

        switch (character.WeaponType)
        {
            case WeaponType.Bow:
                arm = ArmL;
                weapon = character.BowRenderers[3].transform;
                break;
            case WeaponType.Firearms1H:
            case WeaponType.Firearms2H:
                arm = ArmR;
                weapon = Firearm.FireTransform;
                break;
            default:
                return;
        }

        if (character.IsReady())
        {
            /*if ( enemy== null) return;
            Vector3 enemyS = this.enemy.position;
            RotateArm(arm, weapon, FixedArm ? arm.position + 1000 * Vector3.right : enemyS, -40, 40);*/
            RotateArm(arm, weapon, FixedArm ? arm.position + 1000 * Vector3.right : Camera.main.ScreenToWorldPoint(Input.mousePosition), -40, 40);
        }
    }
   
    /// <summary>
    /// Selected arm to position (world space) rotation, with limits.
    /// </summary>
    public void RotateArm(Transform arm, Transform weapon, Vector2 target, float angleMin, float angleMax) // TODO: Very hard to understand logic.
    {
        target = arm.transform.InverseTransformPoint(target);

        var angleToTarget = Vector2.SignedAngle(Vector2.right, target);
        var angleToFirearm = Vector2.SignedAngle(weapon.right, arm.transform.right) * Math.Sign(weapon.lossyScale.x);
        var fix = weapon.InverseTransformPoint(arm.transform.position).y / target.magnitude;

        if (fix < -1) fix = -1;
        if (fix > 1) fix = 1;

        var angleFix = Mathf.Asin(fix) * Mathf.Rad2Deg;
        var angle = angleToTarget + angleToFirearm + angleFix;

        angleMin += angleToFirearm;
        angleMax += angleToFirearm;

        var z = arm.transform.localEulerAngles.z;

        if (z > 180) z -= 360;

        if (z + angle > angleMax)
        {
            angle = angleMax;
        }
        else if (z + angle < angleMin)
        {
            angle = angleMin;
        }
        else
        {
            angle += z;
        }

        if (float.IsNaN(angle))
        {
            Debug.LogWarning(angle);
        }

        arm.transform.localEulerAngles = new Vector3(0, 0, angle);
    }

}
