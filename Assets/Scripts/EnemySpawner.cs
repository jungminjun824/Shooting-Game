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
    private float spawnTime; //积己 林扁
    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float posisionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 position = new Vector3(posisionX, stageData.LimitMax.y + 1.0f, 0.0f);
            //利 某腐磐 积己
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            SpawnEnemyHPSlider(enemyClone);
            yield return new WaitForSeconds(spawnTime);
        }
    }
    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClon = Instantiate(enemyHPSliderPrefab);
        sliderClon.transform.SetParent(canvasTransform);
        sliderClon.transform.localScale = Vector3.one;
    }
}
