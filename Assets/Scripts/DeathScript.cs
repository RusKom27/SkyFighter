using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    private GameObject tv;

    private Animator animator;

    private void Start()
    {
        tv = GameObject.Find("TV");
        animator = GetComponent<Animator>();
    }

    public void End()
    {
        tv.GetComponent<TV>().ChangeStateMenu();
    }
}
