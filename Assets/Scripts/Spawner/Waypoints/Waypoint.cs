using System;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] protected Target _target;
    public Target Target => _target;

    public event Action<Vector3> OnTargetPositionChanged;

    private void Update()
    {
        OnTargetPositionChanged?.Invoke(_target.transform.position);
    }
}
