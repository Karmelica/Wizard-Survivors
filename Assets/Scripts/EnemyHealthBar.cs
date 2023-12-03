using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyScript enemyScript;
    public TextMeshProUGUI tekst;
    // Update is called once per frame
    void Update()
    {
        tekst.text = enemyScript.enemyCurrentHp + " / " + enemyScript.enemyMaxHp;

    }
}
