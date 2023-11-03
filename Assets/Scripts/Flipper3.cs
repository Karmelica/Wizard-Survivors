using UnityEngine;

public class Flipper3 : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer spriteRenderer;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position = new Vector3(player.transform.position.x - 0.2f, player.transform.position.y, 0);
            spriteRenderer.flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position = new Vector3(player.transform.position.x + 0.2f, player.transform.position.y, 0); ;
            spriteRenderer.flipX = false;
        }
    }
}
