using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator animator;
    public Transform pfFireball;
    public GameObject player;
    public float setFireballCooldown = 1f;
    static public float fireballCooldown;
    static public float uiFireballCooldown;

    void Fireball()
    {
        if (Input.GetMouseButtonDown(1) && fireballCooldown <= 0f && Time.timeScale != 0)
        {
            animator.Play("Attack");
            fireballCooldown = setFireballCooldown;
            Instantiate(pfFireball, player.transform.position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        uiFireballCooldown = setFireballCooldown;
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
