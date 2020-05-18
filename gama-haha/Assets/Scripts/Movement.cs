﻿using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 5f;
    [SerializeField]
    private bool canContinueCombo = false;
    [SerializeField]
    private float jumpSpeed = 1f;

    private int comboCounter = 0;
    private bool isCrouching = false;
    private bool isGuarding = false;
    private bool isGrounded = false;

    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private CapsuleCollider2D _capsuleCollider2D;
    private Energy _energy;
    private Damage _damage;
    private Attack _attack;

    private const string LAYER_GROUND = "Ground";

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _energy = GetComponent<Energy>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _damage = GetComponent<Damage>();
        _attack = GetComponentInChildren<Attack>();
;    }

    // Update is called once per frame
    void Update()
    {
        comboCounter = _animator.GetInteger("comboCounter");
        isGrounded = _capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask(LAYER_GROUND));
        _animator.ResetTrigger("punch");
        _animator.ResetTrigger("jump");
        _animator.ResetTrigger("blast");
        _animator.SetBool("canContinueCombo", canContinueCombo);
        _animator.SetBool("isGrounded", isGrounded);

        if (isGrounded)
        {
            Crouch();
            Guard();
            if (!isCrouching && !isGuarding)
            {
                Charging();
                if (!_energy.charging)
                {
                    Run();
                    Jump();
                    Punch();
                    Blast();
                    FlipSprite();
                }
            }
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            _rigidBody.velocity += jumpVelocityToAdd;
            _animator.SetTrigger("jump");
        }
    }

    private void Guard()
    {
        isGuarding = Input.GetKey(KeyCode.G);
        _animator.SetBool("isGuarding", isGuarding);
    }

    private void Charging()
    {
        _energy.charging = Input.GetKey(KeyCode.R);
        _animator.SetBool("isCharging", _energy.charging);
    }

    private void Blast()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetTrigger("blast");
        }
    }

    private void Crouch()
    {
        isCrouching = Input.GetKey(KeyCode.S);
        _animator.SetBool("isCrouching", isCrouching);
    }

    private void Punch()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (canContinueCombo)
            {
                _animator.SetInteger("comboCounter", ++comboCounter);
            }

            //Debug.Log("Going to set damage before attack to " + _damage.damagePerPunchCombo[comboCounter] + " | " + _damage.pushBackPowerPerPunchCombo[comboCounter] + " | " + comboCounter);
            _attack.SetNextAttack(
                _damage.damagePerPunchCombo[comboCounter],
                _damage.pushBackPowerPerPunchCombo[comboCounter]
            );
            
            _animator.SetTrigger("punch");
        }
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, _rigidBody.velocity.y);
        _rigidBody.velocity = playerVelocity;
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        { 
            transform.localScale = new Vector2(Mathf.Sign(_rigidBody.velocity.x), 1f);
        }
        _animator.SetBool("isMoving", playerHasHorizontalSpeed);
    }
}
