using UnityEngine;

public class EnemyRed : Enemy
{
    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.material.color = Color.red;
    }
}
