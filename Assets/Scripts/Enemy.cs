using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [Header("Properties")]
    public Transform player;
    public Rigidbody2D rbody2D;

    [Header("Ruch")]
    public float speed = 4;
    private float enemyMoveX;
    private float enemyMoveY;

    

    void EnemyMove()
    {
        enemyMoveX = transform.position.x;
        enemyMoveY = transform.position.y;
        rbody2D.AddForce(0.5f * -speed * new Vector2(enemyMoveX, enemyMoveY).normalized, ForceMode2D.Force);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
        rbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
}
