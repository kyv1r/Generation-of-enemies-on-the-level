using UnityEngine;

public class EnemyYellow : Enemy
{
    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.material.color = Color.yellow;
    }
}
