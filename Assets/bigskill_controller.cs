using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player_control;

public class bigskill_controller : StateMachineBehaviour
{
    private GameObject Enemy_ref;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemy_ref = GameObject.Find("SmallEnemy");

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerController>().bigskill_timer = 0.0f;
        if (Enemy_ref!=null&&Enemy_ref.GetComponent<EnemyController>().distance < 6.0f)
        {
            Enemy_ref.GetComponent<EnemyController>().currentHP -= 1.5f;
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerController>().is_bigskill_start = false;
        animator.GetComponent<PlayerController>().is_bigskill_cooldown = false;
        animator.GetComponent<PlayerController>().bigskill_timer = 0.0f;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
