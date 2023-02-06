using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _spawnCoins;

    private int _valye = 4;

    public void TakeDamage(int damage)
    {
        _valye -= damage;
        Instantiate(_coin, _spawnCoins.position, _spawnCoins.rotation);

        if (_valye<= 0)
        {
            Destroy(gameObject);
        }
    }
}
