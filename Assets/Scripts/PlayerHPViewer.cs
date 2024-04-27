using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHp playerHP;
    private Slider sliderHP;
    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }

    /// <summary>
    /// Tip. �� ��Ȯ�� ������δ� �̺�Ʈ�� �̿��� ü�� ������ �ٲ𶧸� UI ���� ����
    /// </summary>
    private void Update()
    {
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}
