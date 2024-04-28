using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 35.0f;
    private Transform targetTransform;
    private RectTransform rectTransform;

    public void Setup(Transform target)
    {
        // 슬라이더UI가 쫓아다닐 타겟 설정
        targetTransform = target;
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if(targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        // 오브젝트 월드 좌표를 기준으로 화면에서의 좌표 값을 구함
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPosition + distance;
    }
}
