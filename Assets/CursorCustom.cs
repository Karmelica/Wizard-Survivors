using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCustom : MonoBehaviour
{
    private float mousePos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
