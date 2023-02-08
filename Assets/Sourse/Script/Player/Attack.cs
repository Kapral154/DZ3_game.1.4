using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audio;

    private int _damage = 1;
    private const string _attackTrigger = "Atack";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(_attackTrigger);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            _audio.Play();
            enemy.TakeDamage(_damage);
        }
    }
}
