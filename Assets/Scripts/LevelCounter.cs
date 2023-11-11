using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{
    public Text level;

    public void LevelCount(int amount)
    {
        level.text = "Level: " + amount;
    }
}
