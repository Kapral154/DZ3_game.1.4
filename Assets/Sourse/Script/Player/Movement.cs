using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private const string _isRun = "isRun";
    private const string _isJumpBool = "Jump";
    private const string _jumpTriger = "Jump2";
    private float _speed = 4;
    private float _jumpForse = 5f;
    private float _movementSpeed;
    private bool _isGround;

    private void Update()
    {
        _movementSpeed = Input.GetAxis("Horizontal");
        Reversal(_movementSpeed);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {          
            _rigidbody2D.velocity = new Vector2(_movementSpeed * _speed, _rigidbody2D.velocity.y);           
            _animator.SetBool(_isRun, true);
        }
        else
        {
            _animator.SetBool(_isRun, false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody2D.velocity = Vector2.up * _jumpForse;
            _animator.SetTrigger(_jumpTriger);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Eart>(out Eart eart))
        {
            _isGround = true;
            _animator.SetBool(_isJumpBool, _isGround);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Eart>(out Eart eart))
        {
            _isGround = false;
            _animator.SetBool(_isJumpBool, _isGround);
        }
    }

    private void Reversal(float x)
    {
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }       
    }
}
