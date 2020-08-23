using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class script_IntermediateTarget : Target
{
    [Header("Door 1")]
    [SerializeField] Target Door1 = null;
    Animator Door1_anim;

    [Header("State of door when switch is flipped on")]
    [SerializeField] string Door1_on_state = "";
    
    [Header("State of door when switch is flipped off")]
    [SerializeField] string Door1_off_state = "";
    
    

    [Header("Door 2")]
    [SerializeField] Target Door2 = null;
    Animator Door2_anim;

    [Header("State of door when switch is flipped on")]
    [SerializeField] string Door2_on_state = "";

    [Header("State of door when switch is flipped off")]
    [SerializeField] string Door2_off_state = "";


    [Header("Keeps tracks of state of switch (true -> on, false -> off")]
    bool controller = true;

    private void Awake()
    {
        Door1_anim = Door1.GetComponent<Animator>();
        Door2_anim = Door2.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        string switch_start_state = controller ? "On" : "Off";

        bool Door1_start = Door1_on_state.Equals(switch_start_state);
        bool Door2_start = Door2_on_state.Equals(switch_start_state);

        Door1_anim.SetBool("Off_On", Door1_start);
        Door2_anim.SetBool("Off_On", Door2_start);
    }

    public override void Activate()
    {
        string desired_Door1_state = controller ? Door1_on_state : Door1_off_state;
        string desired_Door2_state = controller ? Door2_on_state : Door2_off_state;

        string current_Door1_state = Door1.GetCurrentState() ? "On" : "Off";
        string current_Door2_state = Door2.GetCurrentState() ? "On" : "Off";

        if (!desired_Door1_state.Equals(current_Door1_state))
            Door1.Activate();
        else
            Door1.InvokeFinishedAnimationEvent();

        if (!desired_Door2_state.Equals(current_Door2_state))
            Door2.Activate();
        else
            Door2.InvokeFinishedAnimationEvent();

        controller = !controller;
    }
}
