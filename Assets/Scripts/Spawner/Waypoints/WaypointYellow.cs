using UnityEngine;
using UnityEngine.Pool;

public class WaypointYellow : Waypoint
{
    [SerializeField] private EnemyYellow _enemyYellowPrefab;

    private ObjectPool<EnemyYellow> _enemyYellowPool;

    public ObjectPool<EnemyYellow> EnemyYellowPool => _enemyYellowPool;

    private void Awake()
    {
        _enemyYellowPool = new ObjectPool<EnemyYellow>(
            createFunc: () => Instantiate(_enemyYellowPrefab),
            actionOnGet: (enemyYellow) => OnGetEnemy(enemyYellow, this),
            actionOnRelease: (enemyYellow) => OnReleaseEnemy(enemyYellow, this));
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
