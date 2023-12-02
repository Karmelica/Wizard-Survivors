using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private Transform pfSlash;
    static public float uiAttackCooldown;
    static public float attackCooldown;
    public float setAttackCooldown = 3f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        uiAttackCooldown = setAttackCooldown;
        attackCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackCooldown <= 0f && Time.timeScale != 0)
        {
            animator.Play("Attack");
            attackCooldown = setAttackCooldown;
            if (transform.rotation.y == 0)
            {
                Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0), transform.rotation);
            }
            else
            {
                Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0) * -1, transform.rotation);
            }
        }
    }
}
