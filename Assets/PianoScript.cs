using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoScript : MonoBehaviour
{
    public GameObject tooltip;
    Animator animator;

    void Start()
    {
        tooltip.SetActive(false);
        animator = GetComponent<Animator>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isTriggered", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tooltip.SetActive(true);
            StartCoroutine("WaitForSec");
            animator.SetBool("isTriggered", true);
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        tooltip.SetActive(false);
    }
}
