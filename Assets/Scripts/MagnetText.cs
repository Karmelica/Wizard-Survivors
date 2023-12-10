using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    
    public IEnumerator Text()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);

        yield return new WaitForSeconds(5);

        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
