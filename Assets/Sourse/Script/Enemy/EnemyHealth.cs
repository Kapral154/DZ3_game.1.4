using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _spawnCoins;

    private int _value = 4;

    public void TakeDamage(int damage)
    {
        _value -= damage;
        Instantiate(_coin, _spawnCoins.position, _spawnCoins.rotation);

        if (_value<= 0)
        {
            Destroy(gameObject);
        }
    }
}
