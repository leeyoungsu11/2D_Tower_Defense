using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Text Timer_Text;
    private float timer;

    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private Transform[] wayPoints2;

    public GameManager gameManager;



    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.buildIndex == 2)
        {
            StartCoroutine(SpawnEnemy1());
        }
        else if (scene.buildIndex == 3)
        {
            StartCoroutine(SpawnEnemy2());
        }
        else if (scene.buildIndex == 4)
        {
            StartCoroutine(SpawnEnemy3());
        }
    }

    private void Start()
    {

        timer = 11;


    }
    private void Update()
    {
        Timer_Text.text = $"{(int)timer}";


        timer -= Time.deltaTime;

        if (timer <= 1)
        {
            Timer_Text.gameObject.SetActive(false);
        }

    }
    private IEnumerator SpawnEnemy1()
    {
        yield return new WaitForSeconds(10);
        {
            gameManager.GetComponent<GameManager>().WaveUp();
            for (int i = 0; i < 5; i++)
            {
                GameObject clone = Instantiate(enemyPrefab[0]);
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(wayPoints, 5);
                yield return new WaitForSeconds(2);
            }

            yield return new WaitForSeconds(5);

            gameManager.GetComponent<GameManager>().WaveUp();
            for (int i = 0; i < 10; i++)
            {
                GameObject clone = Instantiate(enemyPrefab[0]);
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(wayPoints, 5);
                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(8);

            gameManager.GetComponent<GameManager>().WaveUp();
            for (int i = 0; i < 3; i++)
            {
                GameObject clone = Instantiate(enemyPrefab[1]);

                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(wayPoints2, 3);
                yield return new WaitForSeconds(2);
            }

            yield return new WaitForSeconds(5);

            gameManager.GetComponent<GameManager>().WaveUp();
            for (int i = 0; i < 14; i++)
            {
                GameObject clone = Instantiate(enemyPrefab[0]);
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(wayPoints, 8);
                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(5);

            gameManager.GetComponent<GameManager>().WaveUp();
            for (int i = 0; i < 5; i++)
            {
                GameObject clone = Instantiate(enemyPrefab[1]);

                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(wayPoints2, 3);
                yield return new WaitForSeconds(2);

            }
            gameManager.GetComponent<GameManager>().end();
        }
    }

        private IEnumerator SpawnEnemy2()
        {
            yield return new WaitForSeconds(10);
            //while(Wave < 4)
            {
                gameManager.GetComponent<GameManager>().WaveUp();
                for (int i = 0; i < 10; i++)
                {
                    GameObject clone = Instantiate(enemyPrefab[0]);
                    Enemy enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints, 5);
                    yield return new WaitForSeconds(2);
                }

                yield return new WaitForSeconds(3);

                gameManager.GetComponent<GameManager>().WaveUp();
                for (int i = 0; i < 30; i++)
                {
                    GameObject clone = Instantiate(enemyPrefab[0]);
                    Enemy enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints, 5);
                    yield return new WaitForSeconds(1);
                }

                yield return new WaitForSeconds(3);

                gameManager.GetComponent<GameManager>().WaveUp();
                for (int i = 0; i < 10; i++)
                {
                    GameObject clone = Instantiate(enemyPrefab[1]);

                    Enemy enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints2, 4);
                    yield return new WaitForSeconds(0.5f);
                }

                yield return new WaitForSeconds(3);

                gameManager.GetComponent<GameManager>().WaveUp();
                for (int i = 0; i < 30; i++)
                {
                    GameObject clone = Instantiate(enemyPrefab[0]);
                    Enemy enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints, 8);
                    yield return new WaitForSeconds(0.5f);
                }

                yield return new WaitForSeconds(3);

                gameManager.GetComponent<GameManager>().WaveUp();
                for (int i = 0; i < 15; i++)
                {
                    GameObject clone = Instantiate(enemyPrefab[1]);

                    Enemy enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints2, 4);
                    yield return new WaitForSeconds(1);

                }
                gameManager.GetComponent<GameManager>().end();
            }
        }

        private IEnumerator SpawnEnemy3()
        {
            yield return new WaitForSeconds(10);

            {
                gameManager.GetComponent<GameManager>().WaveUp();
                for (int i = 0; i < 1; i++)
                {
                    GameObject clone = Instantiate(enemyPrefab[0]);
                    Enemy enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints, 100);
                    yield return new WaitForSeconds(1);
                }

            }
            gameManager.GetComponent<GameManager>().end();
        }
    
}
