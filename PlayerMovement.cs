using Assets.HeroEditor.Common.CharacterScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public Character Character;
    public CharacterController Controller;
    public Vector3 MouseToChar = Vector3.zero;

    private Vector3 _speed = Vector3.zero;

    public void Start()
    {
        if (Controller == null)
        {
            Controller = Character.gameObject.AddComponent<CharacterController>();
            Controller.center = new Vector3(0, 1.125f);
            Controller.height = 2.5f;
            Controller.radius = 0.75f;
            Controller.minMoveDistance = 0;
        }

        Character.Animator.SetBool("Ready", true);
    }

    public void Update()
    {
        var direction = Vector2.zero;
        if (CrossPlatformInputManager.GetButton("left")) direction.x = -1;
        if (CrossPlatformInputManager.GetButton("right")) direction.x = 1;
        if (CrossPlatformInputManager.GetButtonDown("Jump")) direction.y = 1;


        if (Input.GetKey(KeyCode.LeftArrow)) direction.x = -1;
        if (Input.GetKey(KeyCode.RightArrow)) direction.x = 1;
        if (Input.GetKey(KeyCode.UpArrow)) direction.y = 1;

        Move(direction);

        /*if (Input.GetKeyDown(KeyCode.D))
        {
            Character.SetState(CharacterState.DeathB);
        }*/
        //Turning();
    }

    public void Turning()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 vec3 = new Vector3(mouse.x, mouse.y,this.Character.transform.position.y);
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(vec3);
         this.MouseToChar = mouseWorld - this.Character.transform.position;
        //this.Character.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        this.Character.transform.localScale = new Vector3(Mathf.Sign(this.MouseToChar.x), 1, 1);
    }

    public void Move(Vector2 direction)
    {
        if (Controller.isGrounded)
        {
            _speed = new Vector3(5 * direction.x, 12 * direction.y);

            if (direction != Vector2.zero)
            {
                Turn(_speed.x);
            }
        }

        if (Controller.isGrounded)
        {
            if (direction != Vector2.zero)
            {
                Character.SetState(CharacterState.Run);
            }
            else if (Character.GetState() < CharacterState.DeathB)
            {
                Character.SetState(CharacterState.Idle);
            }
        }
        else
        {
            Character.SetState(CharacterState.Jump);
        }

        _speed.y -= 28 * Time.deltaTime; // Depends on project physics settings
        Controller.Move(_speed * Time.deltaTime);
    }

    public void Turn(float direction)
    {
        Character.transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
    }
}
