using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    /*
    그냥 적 생성해주는 함수
    시간설정가능
    나중에 enemy 스크립트 여러개 만들어주고
    이름도 바꿔야할것
    여기서 wayPoints를 넣어주어야한다.
    */
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private Transform[] wayPoints;

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }
    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            GameObject clone = Instantiate(enemyPrefab);
            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.Setup(wayPoints);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
