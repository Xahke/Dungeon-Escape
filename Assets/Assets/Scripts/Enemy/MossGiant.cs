using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    [SerializeField]
    private Animator _anim;
    public void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        Attack();
    }
    public override void Attack()
    {
        Debug.Log("Moss Giant Attack");
    }

    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
    }
    public void Movement()
    {
        if (transform.position == pointA.position)
        {
            _anim.SetTrigger("Idle");
            _currentTarget = pointB.position;

        }
        else if (transform.position == pointB.position)
        {
            _anim.SetTrigger("Idle");
            _currentTarget = pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
