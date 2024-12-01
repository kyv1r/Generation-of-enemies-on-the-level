using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _repeatTime = 1;

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

    public Vector3 GetRandomDirection()
    {
        List<Vector3> directions = new List<Vector3>()
        {
            Vector3.forward,
            Vector3.right,
            Vector3.left,
            Vector3.back,
        };

        return directions[UnityEngine.Random.Range(0, directions.Count)];
    }

    private void OnGetEnemy(Enemy enemy)
    {
        enemy.transform.position = GetRandomWaypoint().gameObject.transform.position;
        enemy.ReceivePosition(GetRandomDirection());
    }

    private IEnumerator InstantiateEnemy()
    {
        WaitForSeconds repeatRate = new WaitForSeconds(_repeatTime);

        while (enabled)
        {
            _enemyPool.Get();
            yield return repeatRate;
        }
    }

    private Waypoint GetRandomWaypoint()
    {
        return _waypoints[UnityEngine.Random.Range(0, _waypoints.Count)];
    }

}
