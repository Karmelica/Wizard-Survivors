using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Flip()
    {
        if (transform.position.x >= 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }
}
