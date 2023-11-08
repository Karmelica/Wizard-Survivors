using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    private float time = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        EnemySpawn.spawned--;
        Stats.exp++;
    }

    void Start()
    {

    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
