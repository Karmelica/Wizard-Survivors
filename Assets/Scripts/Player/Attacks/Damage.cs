using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int attackDamage = 1;

    public void SetDamage(int newDamage)
    {
        attackDamage = newDamage;
    }
}
