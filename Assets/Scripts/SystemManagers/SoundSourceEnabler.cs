using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSourceEnabler : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector2 distance = player.position - transform.position;
        if(distance.magnitude > 2f)
        {
            source.enabled = false;
        }
        else
        {
            source.enabled = true;
        }
    }
}
