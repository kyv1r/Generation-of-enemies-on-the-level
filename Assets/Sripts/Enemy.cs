using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Spawner _spawner;
    [SerializeField] float _speed;

    private Vector3 _direction;

    private void Awake()
    {
        _direction = _spawner.GetRandomDirection();
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}