using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Button : MonoBehaviour
{
    [SerializeField] script_BridgeLower bridgeLower;

    bool activated = false;


    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag.Equals("Boomerang"))
        //{
            if (!activated)
            {
                Activate();
            }
        //}
    }

    public void Activate()
    {
        activated = true;
        StartCoroutine(MoveAway());
    }


    public IEnumerator MoveAway()
    {
        float time = 0f;
        while ((time += Time.deltaTime) < 1f)
        {
            this.transform.Translate(new Vector3(0f, 0f, 1f) * Time.deltaTime);
            yield return 0;
        }

        this.gameObject.SetActive(false);
        bridgeLower.Activate();
    }

}
