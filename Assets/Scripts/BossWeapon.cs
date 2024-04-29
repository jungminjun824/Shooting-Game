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
        float intervalAngle = 360 / count; //�߻�ü ������ ����
        float weightAngle = 0; //���ߵǴ� ����(�Ի� ���� ��ġ�� �߻����� �ʵ��� ����)

        while (true)
        {
            for ( int i = 0; i < count; ++i )
            {
                //�߻�ü ����
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
        Vector3 targetPosition = Vector3.zero; //��ǥ ��ġ (�߾�)
        float attackRate = 0.1f;

        while (true)
        {
            GameObject clone = Instantiate(projecktilePrefab, transform.position, Quaternion.identity);
            //�߻�ü �̵� ����
            Vector3 direction = (targetPosition - clone.transform.position).normalized;
            //�߻�ü �̵� ���� ����
            clone.GetComponent<Movement2D>().MoveTo(direction);

            yield return new WaitForSeconds(attackRate);
        }
    }
}
