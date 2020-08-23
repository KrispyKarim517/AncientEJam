using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_IntermediateIntermediateTarget : Target
{
    [Header("Doors in Row")]
    [SerializeField] Target Door1 = null;
    Animator Door1_anim;
    [SerializeField] Target Door2 = null;
    Animator Door2_anim;
    [SerializeField] Target Door3 = null;
    Animator Door3_anim;

    private void Awake()
    {
        Door1_anim = Door1.GetComponent<Animator>();
        Door2_anim = Door2.GetComponent<Animator>();
        Door3_anim = Door3.GetComponent<Animator>();
    }

    public override void Activate()
    {
        Door1.Activate();
        Door2.Activate();
        Door3.Activate();
    }

    public void SetAnim(bool state)
    {
        Door1_anim.SetBool("Off_On", state);
        Door2_anim.SetBool("Off_On", state);
        Door3_anim.SetBool("Off_On", state);
    }
}
