using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    [Header("Debug")]
    static public bool godMode = false;
    public bool debugGodMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        godMode = debugGodMode;
    }
}