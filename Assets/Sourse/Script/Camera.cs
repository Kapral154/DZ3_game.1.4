using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _triger;

    private Vector3 _track;
    private float _dumping = 10;

    private void Update()
    {
        _track = Vector3.MoveTowards(transform.position, _triger.transform.position, _dumping * Time.deltaTime);
        transform.position = new Vector3(_track.x, _track.y, transform.position.z);
    }
}
