using UnityEngine;

public class Slash : MonoBehaviour
{
    [SerializeField]
    private float time = 2f;
    static public int heal = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 deadPreFabCoords = collision.gameObject.transform.position;
        Destroy(collision.gameObject);
        Stats.currentHp += heal;
        EnemySpawn.spawned--;
        ExpManager.Instance.AddExp(Enemy.enemyExp);
        FindAnyObjectByType<CoinDrop>().Drop(deadPreFabCoords);
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
