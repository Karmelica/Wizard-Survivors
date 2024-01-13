using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{
    public TextMeshProUGUI level;

    public void LevelCount(int amount)
    {
        level.text = "Level: " + amount;
    }
}
