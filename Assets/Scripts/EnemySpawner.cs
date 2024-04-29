using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private GameObject textBossWarning;
    [SerializeField]
    private GameObject panelBossHP;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private float spawnTime; //생성 주기
    [SerializeField]
    private int maxEnemyCount = 100; // 현재 스테이지의 최대 적 생성 숫자
    private void Awake()
    {
        textBossWarning.SetActive(false);
        boss.SetActive(false);
        panelBossHP.SetActive(false);
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        int currentEnemtCount = 0;
        while (true)
        {
            float posisionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 position = new Vector3(posisionX, stageData.LimitMax.y + 1.0f, 0.0f);
            //적 캐릭터 생성
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            SpawnEnemyHPSlider(enemyClone);

            currentEnemtCount++;
            if(currentEnemtCount == maxEnemyCount)
            {
                StartCoroutine("SpawnBoss");
                break;
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClon = Instantiate(enemyHPSliderPrefab);
        sliderClon.transform.SetParent(canvasTransform);
        sliderClon.transform.localScale = Vector3.one;
        sliderClon.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        sliderClon.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHp>());
    }

    private IEnumerator SpawnBoss()
    {
        textBossWarning.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        textBossWarning.SetActive(false);

        panelBossHP.SetActive(true);

        boss.SetActive(true);

        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }
}
