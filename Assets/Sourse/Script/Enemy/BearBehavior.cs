using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearBehavior : MonoBehaviour
{
    [SerializeField] private Patrol _patrolPoints;
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _animator;

    private Coroutine _attack;
    private WaitForSeconds _attackRecharge = new WaitForSeconds(2f);
    private Transform[] _points;
    private float _sped = 2;
    private int _curentPoint;
    private bool _isAggressiveState = false;
    private string _aggressionBool = "isAggression";
    private string _attackTriger = "Attack";

    private void Start()
    {
        _attack = StartCoroutine(Attack());
        _points = new Transform[_patrolPoints.transform.childCount];

        for (int i = 0; i < _patrolPoints.transform.childCount; i++)
        {
            _points[i] = _patrolPoints.transform.GetChild(i);
        }
    }

    private void Update()
    {
        _animator.SetBool(_aggressionBool, _isAggressiveState);

        if (_isAggressiveState)
        {
            AttackEnemy();
            return;
        }

        Patrol();
    }

    private void Patrol()
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

    private void AttackEnemy()
    {
        if (Vector2.Distance(transform.position, _player.position) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position, _sped * Time.deltaTime);
        }
    }

    private IEnumerator Attack()
    {   
        while (true)
        {
            if (_isAggressiveState)
            {
                _animator.SetTrigger(_attackTriger);                
            }
            yield return _attackRecharge;
        }
    }

    public void ChangeStateAggression(bool isAggressive)
    {
        _isAggressiveState = isAggressive;
    }
}
