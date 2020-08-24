using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    /// <summary>
    /// Set Real Way to get Player later
    /// </summary>
    public GameObject player;

    [SerializeField] Target target = null;

    private Animator animator = null;

    public string desired_equipment = "ERROR_MUST_OVERRIDE";

    private bool state_toggle = false;

    bool okay = true;
    bool colliding = false;
    Collider player_collider = null;

    [SerializeField] float animation_length = 0f;

    public virtual void Activate()
    {
        state_toggle = !state_toggle;

        if (state_toggle)
        {
            animator.SetTrigger("On");
        }
        else
        {
            animator.SetTrigger("Off");
        }

        StartCoroutine(WaitForAnimationEnd());
    }

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            player_collider = other;
            colliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            player_collider = null;
            colliding = false;
        }
    }

    private void Update()
    {
        if (colliding && GameInputManager.GetKeyDown("Interact") && okay)
        {
            Debug.Log("interaction");
            var interact_component = player_collider.GetComponent<script_PlayerInteraction>();
            if (interact_component != null)
            {
                //Debug.Log(other.tag.Equals("Player"));
                var gear_component = interact_component.GetGear();
                if (gear_component.CanUse(desired_equipment))
                {
                    gear_component.Use();
                    this.Activate();
                }
            }
            okay = false;
        }
    }

    public IEnumerator WaitForAnimationEnd()
    {
        yield return new WaitForSecondsRealtime(animation_length);
        //player.Equip();
        target.Activate();
    }

    public void reset_okay()
    {
        okay = true;
        Debug.Log("PRESS");
    }
}

