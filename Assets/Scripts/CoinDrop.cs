using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    public GameObject coin;
    public Transform tr;

    public void Drop()
    {
        Vector3 position = transform.position;
        Object.Instantiate(coin, position, Quaternion.identity);
    }
}
