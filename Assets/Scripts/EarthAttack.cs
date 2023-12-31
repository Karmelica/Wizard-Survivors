using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAttack : MonoBehaviour
{
    private float time = 2f;
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("EarthAttack");
    }
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(gameObject);
        }
    }
}
