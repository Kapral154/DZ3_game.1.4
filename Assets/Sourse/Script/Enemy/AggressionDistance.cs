using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressionDistance : MonoBehaviour
{
    [SerializeField] private TrigerPlayer _player;
    [SerializeField] private BearBehavior _behavior;

    private float _distance = 4;

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < _distance)
        {
            _behavior.EnemyNearby(true);
            return;
        }

        _behavior.EnemyNearby(false);
    }
}
