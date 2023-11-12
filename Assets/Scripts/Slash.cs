using UnityEngine;

public class Slash : MonoBehaviour
{
    [SerializeField]
    public HealthBar healthBar;
    private float time = 1f;
    static public int heal = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 deadPreFabCoords = collision.gameObject.transform.position;
        Destroy(collision.gameObject);
        Stats.currentHp += heal;
        healthBar.SetHealth(Stats.currentHp);
        EnemySpawn.spawned--;
        ExpManager.Instance.AddExp(Enemy.enemyExp);
        FindAnyObjectByType<CoinDrop>().Drop(deadPreFabCoords);
    }

    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
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
