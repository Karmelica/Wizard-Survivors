using UnityEngine;

public class GodMode : MonoBehaviour
{
    [Header("Debug")]
    static public bool godMode;
    public bool setGodMode = false;

    // Start is called before the first frame update
    void Start()
    {
        godMode = setGodMode;
    }
}
