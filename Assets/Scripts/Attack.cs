using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("KeyBinds")]

    public KeyCode attack = KeyCode.Space;

    [SerializeField]
    private Transform pfSlash;
    public float cooldown = 3f;
    private float cooldownOne = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldownOne -= Time.deltaTime;
        if (Input.GetKeyDown(attack) && cooldownOne <= 0f)
        {
            cooldownOne = cooldown;
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
