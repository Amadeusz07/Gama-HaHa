using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (distanceToOpponent < 1f)
        {
            characterControl.run = 0;
            characterControl.punch = true;
        }
        else
        {
            characterControl.run = Mathf.Sign(opponentGameObject.transform.position.x - animator.gameObject.transform.position.x);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
