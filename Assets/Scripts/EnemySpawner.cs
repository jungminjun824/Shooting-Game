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
            //利 某腐磐 积己
            Instantiate(enemyPrefab, new Vector3(posisionX, stageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
