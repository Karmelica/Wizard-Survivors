using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("KeyBinds")]

    public KeyCode attack = KeyCode.Space;

    [SerializeField]
    private Transform pfSlash;
    static public float uiAttackCooldown;
    static public float attackCooldown;
    public float setAttackCooldown = 3f;

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
        if (Input.GetKeyDown(attack) && attackCooldown <= 0f)
        {
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
