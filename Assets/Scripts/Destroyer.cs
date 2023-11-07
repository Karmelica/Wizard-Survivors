using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        EnemySpawner.spawned--;
    }

    void Start()
    {

    }
}
