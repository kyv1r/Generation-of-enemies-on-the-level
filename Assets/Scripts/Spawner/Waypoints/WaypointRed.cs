using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WaypointRed : Waypoint
{
    [SerializeField] private EnemyRed _enemyRedPrefab;

    private ObjectPool<EnemyRed> _enemyRedPool;

    public ObjectPool<EnemyRed> EnemyRedPool => _enemyRedPool;

    private void Awake()
    {
        _enemyRedPool = new ObjectPool<EnemyRed>(
            createFunc: () => Instantiate(_enemyRedPrefab),
            actionOnGet: (enemyRed) => OnGetEnemy(enemyRed, this),
            actionOnRelease: (enemyRed) => OnReleaseEnemy(enemyRed, this));
    }

    private void OnGetEnemy(Enemy enemy, Waypoint waypoint)
    {
        enemy.transform.position = waypoint.transform.position;
        waypoint.OnTargetPositionChanged += enemy.UpdateDirection;
    }

    private void OnReleaseEnemy(Enemy enemy, Waypoint waypoint)
    {
        waypoint.OnTargetPositionChanged -= enemy.UpdateDirection;
    }
}
