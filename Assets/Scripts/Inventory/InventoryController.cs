using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class InventoryController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowHideInventory()
    {
        if(animator != null)
        {
            var currentState = animator.GetBool(SHOW);
            animator.SetBool(SHOW, !currentState);
        }
    }
}
