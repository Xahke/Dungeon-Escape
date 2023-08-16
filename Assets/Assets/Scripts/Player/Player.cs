using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour,IDamageable
{
    public int Health { get; set; }
    public bool CanAttack { get; set; }
    [SerializeField]
    public int gems = 0;
    Rigidbody2D rigidBody2D;
    [SerializeField]
    private float speed = 2.5f;
    public float jumpForce=7f;
    private bool jumpCooldown;
    private bool _isGrounded = false;
    private PlayerAnimation _animScript;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _spriteRendererSwordArc;
    [SerializeField]
    private PlayerInput _playerInput;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        _animScript = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRendererSwordArc = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _playerInput = GetComponent<PlayerInput>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }
   
    void Attack()
    {
        if (_playerInput.actions["Attack"].triggered && CheckTouchGround() == true)
        {
            _animScript.Attack();
        }
    }
    void Movement()
    {
        Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0,0);
        _isGrounded = CheckTouchGround();
        _animScript.GetMoveDirection(input.x);
        Flip(input.x);

        rigidBody2D.velocity = new Vector2(input.x*speed, rigidBody2D.velocity.y);

        if (_playerInput.actions["Jump"].triggered  && CheckTouchGround() == true)
        {
            _animScript.Jump(true);
            rigidBody2D.velocity = new Vector2(0, jumpForce);
            StartCoroutine(JumpCooldown());
        }
    }
    bool CheckTouchGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
        if (hit.collider!=null)
        {
            if (jumpCooldown==false)
            {
                _animScript.Jump(false);
                return true;
                
            }

        }
        return false;
    }
    void Flip(float move)
    {
        if (move < 0)
        {
            _spriteRenderer.flipX = true;
            _spriteRendererSwordArc.flipX = true;
            _spriteRendererSwordArc.flipY = true;
            Vector3 newPos = _spriteRendererSwordArc.transform.localPosition;
            newPos.x = -1.19f;
            _spriteRendererSwordArc.transform.localPosition = newPos;

        }
        else if (move > 0)
        {
            _spriteRenderer.flipX = false;
            _spriteRendererSwordArc.flipX = false;
            _spriteRendererSwordArc.flipY = false;
            Vector3 newPos = _spriteRendererSwordArc.transform.localPosition;
            newPos.x = 1.19f;
            _spriteRendererSwordArc.transform.localPosition = newPos;
        }
    }
    IEnumerator JumpCooldown()
    {
        jumpCooldown = true;
        yield return new WaitForSeconds(0.1f);
        jumpCooldown = false;
    }

    public void Damage()
    {
        if (Health<1)
        {
            return;
        }
        Health--;
        UIManager.Instance.UpdateLives(Health);
        if (Health<1)
        {
            _animScript.Death();
        }
    }
    public void AddGem()
    {
        gems++;
        UIManager.Instance.WriteGemCount(gems);
    }
}
