using UnityEngine;

public class EnemyBlue : Enemy
{
    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.material.color = Color.blue;
    }
}
