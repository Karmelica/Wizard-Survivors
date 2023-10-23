using UnityEngine;

public class Attack : MonoBehaviour

{
    [SerializeField]
    public SpriteRenderer anim;
    public float cooldown = 3.0f;

    void SwordSwing()
    {
        cooldown = 3.0f;
        anim.enabled = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f)
        {
            SwordSwing();
        }
    }
}
