using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // 부딪힌 오브젝트 삭제
            Destroy(collision.gameObject);
            // 내 오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
