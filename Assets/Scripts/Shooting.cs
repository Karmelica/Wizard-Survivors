using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform pfFireball;
    
    public Transform player;
    [Header("Controls")]

    public KeyCode Shoot = KeyCode.Mouse0;

    void Fireball()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(pfFireball, player.transform.position, Quaternion.identity);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    // Update is called once per frame
    void Update()
    {
        Fireball();
    }

    
}
