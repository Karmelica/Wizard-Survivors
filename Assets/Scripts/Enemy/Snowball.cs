using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public Transform snowman;
    private Transform player;
    private Rigidbody2D rb;
    private float despawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        float posX = transform.position.x - player.transform.position.x;
        float posY = transform.position.y - player.transform.position.y;
        rb.AddForce(new Vector2(posX, posY).normalized * -2f, ForceMode2D.Impulse);
    }

    private void Update()
    {
        despawnTime -= Time.deltaTime;
        if ( despawnTime < 0 )
        {
            Destroy(this);
        }
    }

}
