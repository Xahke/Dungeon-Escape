using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _animSword;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _animSword = transform.GetChild(1).GetComponent<Animator>();
    }

    public void GetMoveDirection(float _direction)
    {
        _anim.SetFloat("Move_Direction", Mathf.Abs(_direction));
    }
    public void Jump(bool isJumping)
    {
        _anim.SetBool("isJumping", isJumping);
    }
    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _animSword.SetTrigger("SwordAnimation");
    }
}
