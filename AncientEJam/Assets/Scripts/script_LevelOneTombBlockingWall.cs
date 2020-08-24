using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_LevelOneTombBlockingWall : MonoBehaviour
{
    Collider m_collider;

    bool once = true;

    private void Start()
    {
        m_collider = this.GetComponent<Collider>();
        m_collider.enabled = false;
    }

    public void WhenTriggerPassed()
    {
        if (once)
            StartCoroutine(MoveUp());
        once = false;
    }

    private IEnumerator MoveUp()
    {
        float time = 0f;
        while ((time += Time.deltaTime) < 1f)
        {
            this.transform.Translate(new Vector3(0f, 2.9f, 0f) * Time.deltaTime);
            yield return 0;
        }
        m_collider.enabled = true;
    }
}
