using UnityEngine;

public class Movement : MonoBehaviour
{

    [Header("Ruch")]
    public Rigidbody2D rbody;
    public float speed = 5;
    private float moveX;
    private float moveY;


    void MyInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rbody.AddForce(1f * -speed * new Vector2(moveX, moveY).normalized, ForceMode2D.Force);
        }
        else
        {
            rbody.AddForce(0.5f * -speed * new Vector2(moveX, moveY).normalized, ForceMode2D.Force);
        }
    }
}
