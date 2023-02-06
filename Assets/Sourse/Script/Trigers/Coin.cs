using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private float _startSpawn = 0.4f;
    private float _dropRate = 1.3f;

    private void Update()
    {
        if (_startSpawn > 0)
        {
            _rigidbody2D.AddForce(transform.up * _dropRate);
            _startSpawn -= Time.deltaTime;
        }    
    }
}
