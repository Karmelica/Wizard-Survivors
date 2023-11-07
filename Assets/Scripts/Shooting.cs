using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform pfFireball;
    public GameObject player;

    void Fireball()
    {
        if (Input.GetMouseButtonDown(1))
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
