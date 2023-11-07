using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform pfFireball;

    public GameObject player;
    [Header("Controls")]

    public KeyCode Shoot = KeyCode.Mouse0;

    void Fireball()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(pfFireball, player.transform.position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        Fireball();
    }


}
