using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float Gravity = 9.8f;
    public float JumpForce;
    public float Speed;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        if (_moveVector != Vector3.zero)
        {
            animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
            animator.SetBool("IsGrounded", false);

        }
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Time.fixedDeltaTime * Speed);

        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
            animator.SetBool("IsGrounded", true);
        }
    }
}
