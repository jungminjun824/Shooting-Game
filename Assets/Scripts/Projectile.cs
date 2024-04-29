using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHp>().TakeDamage(damage);
            // �� ������Ʈ ����
            Destroy(gameObject);
        }
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHP>().TakeDamage(damage);
            // �� ������Ʈ ����
            Destroy(gameObject);
        }
    }
}
