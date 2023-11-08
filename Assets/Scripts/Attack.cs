using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("KeyBinds")]

    public KeyCode attack = KeyCode.Space;

    [SerializeField]
    private Transform pfSlash;
    static public float attackCooldown = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(attack) && attackCooldown <= 0f)
        {
            attackCooldown = 3f;
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
