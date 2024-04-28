using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPViewer : MonoBehaviour
{
    private EnemyHp enemyHP;
    private Slider hpSlider;

    public void Setup(EnemyHp enemyHP)
    {
        this.enemyHP = enemyHP;
        hpSlider = GetComponent<Slider>();
    }
    private void Update()
    {
        hpSlider.value = enemyHP.CurrentHP / enemyHP.MaxHp;
    }
}
