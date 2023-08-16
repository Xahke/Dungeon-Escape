using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
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
    public float jumpForce=5f;
    private bool jumpCooldown;
    private bool _isGrounded = false;
    private PlayerAnimation _animScript;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _spriteRendererSwordArc;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        _animScript = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRendererSwordArc = transform.GetChild(1).GetComponent<SpriteRenderer>();
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
        if (Input.GetMouseButtonDown(0)&& CheckTouchGround() == true)
        {
            _animScript.Attack();
        }
    }
    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _isGrounded = CheckTouchGround();
        _animScript.GetMoveDirection(move);
        Flip(move);

        rigidBody2D.velocity = new Vector2(move*speed, rigidBody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && CheckTouchGround() == true)
        {
            _animScript.Jump(true);
            rigidBody2D.velocity = new Vector2(rigidBody2D.position.x, jumpForce);
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
