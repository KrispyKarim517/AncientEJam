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

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).Equals(stateInfo))
        {
            switch_class.AnimationEnd();
        }
    }
}
