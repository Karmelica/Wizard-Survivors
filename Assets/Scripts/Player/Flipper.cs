using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    void Flip()
    {
        if (player.transform.position.x <= transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }
}
