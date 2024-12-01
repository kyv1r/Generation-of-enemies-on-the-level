using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;

    private Vector3 _direction;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void ReceivePosition(Vector3 direction)
    {
        _direction = direction;
    }
}
