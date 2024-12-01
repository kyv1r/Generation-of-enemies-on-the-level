using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetDirection;

    public Rigidbody Rigidbody { get; protected set; }
    public Renderer Renderer { get; protected set; }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetDirection, _speed * Time.deltaTime);
    }

    public void UpdateDirection(Vector3 newTargetPosition)
    {
        _targetDirection = newTargetPosition;
    }
}