using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnOff()
    {
        animator.SetBool("on", !animator.GetBool("on"));
    }
}
