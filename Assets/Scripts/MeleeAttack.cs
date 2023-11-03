using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.isPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacja");
            anim.Play();
        }
    }
}
