using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float despawnTime = 100f;
    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPosition;
    readonly float moveSpeed = 10;

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        hasTarget = true;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
