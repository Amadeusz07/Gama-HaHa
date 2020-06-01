using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBase : StateMachineBehaviour
{
    private const string PLAYER_TAG = "Player";
    protected CharacterControl characterControl;
    protected GameObject opponentGameObject;
    protected float distanceToOpponent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        characterControl = animator.GetComponent<CharacterControl>();
        opponentGameObject = GameObject.FindGameObjectWithTag(PLAYER_TAG);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distanceToOpponent = Vector2.Distance(animator.gameObject.transform.position, opponentGameObject.transform.position);
        Debug.Log("Parent: ");
        characterControl.run = 0;
        characterControl.punch = false;
    }
}
