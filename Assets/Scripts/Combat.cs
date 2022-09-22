using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] KeyCode StanceUp;
    [SerializeField] KeyCode StanceDown;
    [SerializeField] KeyCode Attack;
    AnimState animState = AnimState.Mid;

    enum AnimState
    {
        Top = 1,
        Mid = 0,
        Bot = -1
    }
    void Start()
    {
        animator.SetInteger("Stance", (int)animState);
    }

    void Update()
    {
        StanceChange();
        AttackMove();
    }

    void StanceChange()
    {
        int num = (int)animState;
        if (Input.GetKeyDown(StanceUp))
        {
            num++;   
        }

        if (Input.GetKeyDown(StanceDown))
        {
            num--;
        }
        num = Mathf.Clamp(num, -1, 1);
        animState = (AnimState)num;
        animator.SetInteger("Stance", num);


    }

    void AttackMove()
    {
        if (Input.GetKeyDown(Attack))
        {
            animator.SetTrigger("Stab");
        }
    }
}
    
