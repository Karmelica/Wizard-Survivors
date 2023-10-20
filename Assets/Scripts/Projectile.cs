using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D body;
    public Vector3 mousePos;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
    void MousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        MousePos();
        body = GetComponent<Rigidbody2D>();
        body.AddForce(50f * mousePos.normalized, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
    }
}
