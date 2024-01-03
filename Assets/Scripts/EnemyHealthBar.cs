using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyScript enemyScript;
    public TextMeshProUGUI tekst;

    public void UpdateText()
    {
        tekst.text = enemyScript.enemyCurrentHp + " / " + enemyScript.enemyMaxHp;
    }
}
