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
    /// Tip. 더 정확한 방법으로는 이벤트를 이용해 체력 정보가 바뀔때만 UI 정보 갱신
    /// </summary>
    private void Update()
    {
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}
