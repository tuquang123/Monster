using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldieRun
: StateMachineBehaviour
{
    public float speed = 2.5f;
    Transform enemy;
    Rigidbody rb;
    Enemy2 enemy2;

    // input gan cac valiable
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        rb = animator.GetComponent<Rigidbody>();
        enemy2 = animator.GetComponent<Enemy2>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //enemy.LookAtPlayer();

        // find position player in x 
        Vector2 target = new Vector2(enemy.position.x, rb.position.y);

        // find and direction -> target with speed * time 
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


    }

}