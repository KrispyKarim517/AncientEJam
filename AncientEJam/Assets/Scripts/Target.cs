using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    Collider blocker;
    Animator animator;

    public bool state_toggle = false;

    public UnityEvent animation_complete = new UnityEvent();

    [SerializeField] float animation_length = 0f;
    private void Awake()
    {
        blocker = this.GetComponent<Collider>();
        animator = this.GetComponent<Animator>();
    }

    public virtual void Activate()
    {
        state_toggle = !state_toggle;
        animator.SetBool("Off_On", state_toggle);
        StartCoroutine(WaitForAnimationEnd());
    }

    public IEnumerator WaitForAnimationEnd()
    {
        yield return new WaitForSecondsRealtime(animation_length);
        blocker.enabled = !state_toggle;
        animation_complete.Invoke();
    }

    public void InvokeFinishedAnimationEvent()
    {
        animation_complete.Invoke();
    }

    public bool GetCurrentState()
    {
        return state_toggle;
    }
}
