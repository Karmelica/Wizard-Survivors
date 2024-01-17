using UnityEngine;

public class TpToPlayer : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        if (player.transform.rotation.eulerAngles.y == 180)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
