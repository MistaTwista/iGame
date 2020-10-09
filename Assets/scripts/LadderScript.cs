using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    private int state = 1;
    private int statesCount = 2;
    private Animator animator;
    private List<string> actions;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        actions = new List<string>();
    }

    public void Action(string fromName)
    {
        Debug.Log("Ladder ACTION");
        if (actions.Contains(fromName))
        {
            return;
        }

        if (state > statesCount) { return; }
        animator.SetInteger("state", state);
        state += 1;
        actions.Add(fromName);
    }
}
