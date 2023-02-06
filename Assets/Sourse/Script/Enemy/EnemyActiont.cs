using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiont : MonoBehaviour
{
    [SerializeField] private Patrol _patrolPoints;
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _animator;

    private Transform[] _points;
    private float _reloadAttack = 2;
    private float _sped = 2;
    private float _startReloadAttack;
    private int _curentPoint;
    private bool _isAttack = false;
    private string _isAggression = "isAggression";
    private string _attackTriger = "Attack";

    private void Start()
    {
        _startReloadAttack = _reloadAttack;
        _points = new Transform[_patrolPoints.transform.childCount];

        for (int i = 0; i < _patrolPoints.transform.childCount; i++)
        {
            _points[i] = _patrolPoints.transform.GetChild(i);
        }
    }

    private void Update()
    {
        _animator.SetBool(_isAggression, _isAttack);

        if (_isAttack == false)
        {
            Transform target = _points[_curentPoint];
            transform.position = Vector3.MoveTowards(transform.position, target.position, _sped * Time.deltaTime);

            if (transform.position == target.position)
            {
                _curentPoint++;

                if (_curentPoint >= _points.Length)
                {
                    _curentPoint = 0;
                }
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, _player.position) < 1)
            {
                PerformAttack();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.position, _sped * Time.deltaTime);
            }
        }
    }

    public void Attack(bool isAttack)
    {
        _isAttack = isAttack;       
    }

    private void PerformAttack()
    {
        if (_reloadAttack <= 0)
        {
            _animator.SetTrigger(_attackTriger);
            _reloadAttack = _startReloadAttack;
        }
        else
        {
            _reloadAttack -= Time.deltaTime;
        }
    }
}
