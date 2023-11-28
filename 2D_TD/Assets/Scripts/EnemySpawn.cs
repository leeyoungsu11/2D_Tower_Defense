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
    private GameObject[] enemyPrefab;
    
    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private Transform[] wayPoints2;

    public GameManager gameManager;

    private void Awake()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        //while(Wave < 4)
        {
            gameManager.GetComponent<GameManager>().WaveUp();
            for (int i = 0; i < 20; i++)
            {
                GameObject clone = Instantiate(enemyPrefab[0]);
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(wayPoints);
                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(5);

            gameManager.GetComponent<GameManager>().WaveUp();
            for (int i = 0; i < 8; i++)
            {
                GameObject clone = Instantiate(enemyPrefab[0]);
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(wayPoints);
                yield return new WaitForSeconds(2);
            }

            yield return new WaitForSeconds(5);

            gameManager.GetComponent<GameManager>().WaveUp();
            for (int i = 0; i < 3; i++)
            {
                GameObject clone = Instantiate(enemyPrefab[1]);

                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(wayPoints2);
                yield return new WaitForSeconds(2);
            }

            yield return new WaitForSeconds(5);

            gameManager.GetComponent<GameManager>().WaveUp();
            for (int i = 0; i < 12; i++)
            {
                GameObject clone = Instantiate(enemyPrefab[0]);
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(wayPoints);
                yield return new WaitForSeconds(2);
            }

            yield return new WaitForSeconds(5);

            gameManager.GetComponent<GameManager>().WaveUp();
            for (int i = 0; i < 5; i++)
            {
                GameObject clone = Instantiate(enemyPrefab[1]);

                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(wayPoints2);
                yield return new WaitForSeconds(2);
            }
        }
    }
}
