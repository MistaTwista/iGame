using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class MusicBoxScript : MonoBehaviour, IActionable, ITouchable
{
    public GameObject tooltip;
    public GameObject dancer;
    public LadderScript actionable;
    public GameObject ladder;
    Animator animator;
    private bool isOn = true;

    void Start()
    {
        tooltip.SetActive(false);
        animator = dancer.GetComponent<Animator>();
        actionable = ladder.GetComponent<LadderScript>();
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    tooltip.SetActive(false);
    //    StartCoroutine("WaitForSec");
    //}

    public void Action()
    {
        Animate();
        Debug.Log("MB Action");
        if (actionable != null)
        {
            Debug.Log("MB->Ladder Action");
            actionable.Action("MusicBox");
        }
    }

    public void Touch()
    {
        ShowTooltip();
    }

    public void Untouch()
    {
        HideTooltip();
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        StopAnimation();
    }

    private void ShowTooltip()
    {
        tooltip.SetActive(true);
    }
    
    private void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    private void Animate()
    {
        animator.SetBool("isOn", true);
    }

    private void StopAnimation()
    {
        animator.SetBool("isOn", false);
    }
}
