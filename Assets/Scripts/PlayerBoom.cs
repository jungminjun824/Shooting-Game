using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private int damage = 100;
    private float boomDelay = 0.5f;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        StartCoroutine("MoveToCenter");
    }

    private IEnumerator MoveToCenter()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Vector3.zero;
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / boomDelay;

            //boomDelay에 설정된 시간동안 startposition부터 endposition까지 이동
            //curve에 설정된 그래프처럼 처음에는 빠르게 이동하고, 목적지에 다다를수록 천천히 이동
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percent));
            yield return null;
        }

        animator.SetTrigger("onBoom");
    }
    public void OnBoom()
    {
        //현재 게임 내에서 Enemy 태그를 가진 모든 오브젝트 정보를 가져온다
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteorite");

        //모든 적 파괴
        for (int i = 0; i < enemys.Length; ++i)
        {
            enemys[i].GetComponent<Enemy>().OnDie();
        }
        
        //모든 운석 파괴
        for ( int i = 0; i < meteorites.Length; ++i)
        {
            meteorites[i].GetComponent<Meteorite>().OnDie();
        }

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        for (int i = 0; i < projectiles.Length; ++i)
        {
            projectiles[i].GetComponent<EnemyProjectile>().OnDie();
        }

        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if ( boss != null)
        {
            boss.GetComponent<BossHP>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
