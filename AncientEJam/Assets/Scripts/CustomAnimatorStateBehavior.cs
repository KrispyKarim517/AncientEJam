using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnimatorStateBehavior : StateMachineBehaviour
{

    [SerializeField] Animator animator;

    Switch switch_class = null;

    public void SetSwitch(Switch m_switch)
    {
        switch_class = m_switch;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("first"))
        {
            //switch_class.AnimationStart();
            Debug.Log("1");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("second"))
        {
            //switch_class.AnimationEnd();
            Debug.Log("2");
        }
    }
}
