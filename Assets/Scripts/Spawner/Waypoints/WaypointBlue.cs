using UnityEngine;
using UnityEngine.Pool;

public class WaypointBlue : Waypoint
{
    [SerializeField] private EnemyBlue _enemyBluePrefab;

    private ObjectPool<EnemyBlue> _enemyBluePool;

    public ObjectPool<EnemyBlue> EnemyBluePool => _enemyBluePool;

    private void Awake()
    {
        _enemyBluePool = new ObjectPool<EnemyBlue>(
            createFunc: () => Instantiate(_enemyBluePrefab),
            actionOnGet: (enemyBlue) => OnGetEnemy(enemyBlue, this),
            actionOnRelease: (enemyBlue) => OnReleaseEnemy(enemyBlue, this));
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
