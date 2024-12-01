using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private WaypointRed _waypointRed;
    [SerializeField] private WaypointBlue _waypointBlue;
    [SerializeField] private WaypointYellow _waypointYellow;
    [SerializeField] private float _repeatTime = 2;

    private void Start()
    {
        StartCoroutine(InstantiateEnemies());
    }

    private IEnumerator InstantiateEnemies()
    {
        WaitForSeconds repeatRate = new WaitForSeconds(_repeatTime);

        while (enabled)
        {
            _waypointRed.EnemyRedPool.Get();
            _waypointBlue.EnemyBluePool.Get();
            _waypointYellow.EnemyYellowPool.Get();
            yield return repeatRate;
        }
    }

}
