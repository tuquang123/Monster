using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : StateMachineBehaviour
{
    public float speed = 2.5f;
    Transform player;
    Rigidbody rb;
    Enemy2 enemy;

    // input gan cac valiable
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Tower").transform;
        rb = animator.GetComponent<Rigidbody>();
        enemy = animator.GetComponent<Enemy2>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //enemy.LookAtPlayer();

        // find position player in x 
        Vector2 target = new Vector2(player.position.x, rb.position.y);

        // find and direction -> target with speed * time 
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       

    }

}