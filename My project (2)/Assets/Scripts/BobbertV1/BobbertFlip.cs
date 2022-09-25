using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbertFlip : StateMachineBehaviour
{
    // faceRight used to control changing Vector3() every frame.
    bool faceRight = true;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // https://youtu.be/MbWK8bCAU2w
        
        float moveX = animator.GetFloat(AnimationParams.moveX);
        

        if(moveX == 0){}

        // if moving right (sad) and wasn't facing right, face right.
        else if(moveX > 0 && !faceRight) 
        {
            animator.transform.localScale = new Vector3(1, 1, 1);
            faceRight = !faceRight;
            //Debug.Log(faceRight);   
        }

        // if moving left (big hap) and wasn't facing left, face left.
        else if(moveX < 0 && faceRight){
            animator.transform.localScale = new Vector3(-1, 1, 1);
            faceRight = !faceRight;
            //Debug.Log(faceRight);
        }
    }


    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}
