using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper2 : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0)
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
