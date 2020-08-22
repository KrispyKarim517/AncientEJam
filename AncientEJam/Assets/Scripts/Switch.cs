using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Switch : MonoBehaviour
{
    /// <summary>
    /// Set Real Way to get Player later
    /// </summary>
    public GameObject player;

    [SerializeField] Target target = null;

    private Animator animator = null;

    public string desired_equipment = "ERROR_MUST_OVERRIDE";

    private bool state_toggle = false;

    StateMachineBehaviour animator_state_machine;

    public abstract void Activate();
    public void AnimationEnd()
    {
        // Won't compile until player script is written
        //player.Equip();
    }


}

