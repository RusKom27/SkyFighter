using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject tv;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnOff()
    {
        if (tv)
        {

            GetComponent<Animator>().SetTrigger("transition");
            animator.SetBool("on", !tv.GetComponent<TV>().onMenu);
        }
            
        else
            animator.SetBool("on", !animator.GetBool("on"));
    }
}
