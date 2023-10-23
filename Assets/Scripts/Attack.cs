using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour

{
    [SerializeField]
    public SpriteRenderer anim;
    public float cooldown = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 1.0f)
        {
            anim.enabled = true;
        }
        if (cooldown <= 0.0f) {
            cooldown = 4.0f;
            anim.enabled = false;
        }
    }
}
