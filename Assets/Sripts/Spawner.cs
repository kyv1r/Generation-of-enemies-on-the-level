using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private Enemy _enemyPrefab;

    private ObjectPool<Enemy> _enemyPool;

    private void Awake()
    {
        _enemyPool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_enemyPrefab),
            actionOnGet: (enemy) => OnGetEnemy(enemy));
    }

    private void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }

    private void OnGetEnemy(Enemy enemy)
    {
        enemy.transform.position = GetRandomWaypoint().gameObject.transform.position;
    }

    private IEnumerator InstantiateEnemy()
    {
        while (true)
        {
            WaitForSeconds _repeatRate = new WaitForSeconds(1);
            _enemyPool.Get();
            yield return _repeatRate;
        }
    }

    private Waypoint GetRandomWaypoint()
    {
        return _waypoints[UnityEngine.Random.Range(0, _waypoints.Count)];
    }

    public Vector3 GetRandomDirection()
    {
        List<Vector3> directions = new List<Vector3>()
        {
            Vector3.forward,
            Vector3.right,
            Vector3.left,
        };

        return directions[UnityEngine.Random.Range(0, directions.Count)];
    }
}
