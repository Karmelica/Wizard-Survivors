using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform pfFireball;
    public GameObject player;
    static public float fireballCooldown = 1f;

    void Fireball()
    {
        if (Input.GetMouseButtonDown(1) && fireballCooldown <= 0f)
        {
            fireballCooldown = 1f;
            Instantiate(pfFireball, player.transform.position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fireballCooldown = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        fireballCooldown -= Time.deltaTime;
        Fireball();
    }


}
