using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private GameObject player;

    void Flip()
    {
        if (player.transform.position.x <= transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }
}
