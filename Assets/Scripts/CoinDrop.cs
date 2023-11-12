using System.Linq.Expressions;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    public GameObject prefab;
    public Transform tr;

    void Start()
    {
        prefab = Resources.Load("Coin") as GameObject;
    }

    public void Drop(Vector3 deadPreFabPosition)
    {
        GameObject.Instantiate(prefab, deadPreFabPosition, Quaternion.identity);
    }
}
