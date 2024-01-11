using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public Collider2D playerCollider;
    private void OnTriggerStay2D(Collider2D collision)
    {
        playerCollider.isTrigger = false;
    }
}
