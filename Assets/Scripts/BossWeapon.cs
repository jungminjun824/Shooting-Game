using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { CircleFire = 0, SingleFireToCenterPosition }
public class BossWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projecktilePrefab;

    public void StartFiring(AttackType attackType)
    {
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)
    {
        StopCoroutine(attackType.ToString());
    }

    private IEnumerator CircleFire()
    {
        float attackRate = 0.5f;
        int count = 30;
        float intervalAngle = 360 / count; //발사체 사이의 각도
        float weightAngle = 0; //가중되는 각도(함상 같은 위치로 발사하지 않도록 설정)

        while (true)
        {
            for ( int i = 0; i < count; ++i )
            {
                //발사체 생성
                GameObject clone = Instantiate(projecktilePrefab, transform.position, Quaternion.identity);

                float angle = weightAngle = intervalAngle * i;

                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

                clone.GetComponent<Movement2D>().MoveTo(new Vector3(x, y));
            }
            weightAngle += 1;

            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator SingleFireToCenterPosition()
    {
        Vector3 targetPosition = Vector3.zero; //목표 위치 (중앙)
        float attackRate = 0.1f;

        while (true)
        {
            GameObject clone = Instantiate(projecktilePrefab, transform.position, Quaternion.identity);
            //발사체 이동 방향
            Vector3 direction = (targetPosition - clone.transform.position).normalized;
            //발사체 이동 방향 설정
            clone.GetComponent<Movement2D>().MoveTo(direction);

            yield return new WaitForSeconds(attackRate);
        }
    }
}
