using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollection : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Text _text;

    private int _numberCoins;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            _numberCoins++;
            _audio.Play();
            _text.text = ("Монет собранно: " + _numberCoins);
            Destroy(collision.gameObject);
        }
    }
}
