using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    public EnemySpawner spawner;

    public float time = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        spawner.spawned--;
    }

    void Start()
    {
        spawner = EnemySpawner.FindObjectOfType<EnemySpawner>();
    }
}
