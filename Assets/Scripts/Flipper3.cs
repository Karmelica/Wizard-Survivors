using UnityEngine;

public class Flipper3 : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer spriteRenderer;
    public Transform player;


    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position = new Vector3(player.position.x + -0.2f, player.position.y, 0);
            spriteRenderer.flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position = new Vector3(player.position.x + 0.2f, player.position.y, 0); ;
            spriteRenderer.flipX = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }
}
