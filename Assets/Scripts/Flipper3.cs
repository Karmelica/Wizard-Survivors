using UnityEngine;

public class Flipper3 : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;


    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position = new Vector3(-0.2f, 0, 0); ;
            spriteRenderer.flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position = new Vector3(0.2f, 0, 0); ;
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
