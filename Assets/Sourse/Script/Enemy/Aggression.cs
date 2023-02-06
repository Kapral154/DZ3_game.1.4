using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggression : MonoBehaviour
{
    [SerializeField] private TrigerPlayer _player;
    [SerializeField] private EnemyActiont _enemyActiont;

    private float _distance = 4;

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < _distance)
        {
            _enemyActiont.Attack(true);
        }   
        else
        {
            _enemyActiont.Attack(false);
        }
    }
}
