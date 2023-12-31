using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D colRange;
    public GameObject bulletPrefab; // 발사될 총알 프리팹
    public Transform firePoint; // 총알이 발사될 위치
    public float rotationSpeed = 10f; // 타워의 회전 속도
    public int maxBulletCount = 30; // 최대 총알 수
    //public UnitSet unit; 
    Vector3 direction;

    private UnitSet unit;
    private float attackSpeed = 0f;
    private float attackRange = 0; // 타워의 공격 범위
    private List<GameObject> Enemyes;
    private GameObject targetEnemy; // 현재 추적 중인 적
    private List<GameObject> bulletList = new List<GameObject>(); // 생성된 총알을 담을 리스트

    public Coroutine cor= null ;
    void Start()
    {
        // 총알 프리팹을 기반으로 총알을 생성하여 타워의 자식으로 추가함
        for (int i = 0; i < maxBulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(0,0,0), firePoint.rotation);
            bullet.SetActive(false); // 처음에는 모든 총알을 비활성화 상태로 설정
            bulletList.Add(bullet); // 리스트에 총알 추가
        }

        Enemyes = new List<GameObject>();
        colRange = GetComponent<CircleCollider2D>();
        //unit = GetComponent<UnitSet>();
        //attackRange = unit.ShotRange;
        //attackSpeed = unit.ShotSpeed;

    }
    public void Setup(Vector3 vec, UnitSet unitSet)
    {
        transform.position = vec;
        for (int i = 0; i < maxBulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(0, 0, 0), firePoint.rotation);
            bullet.SetActive(false); // 처음에는 모든 총알을 비활성화 상태로 설정
            bulletList.Add(bullet); // 리스트에 총알 추가
        }

        Enemyes = new List<GameObject>();
        colRange = GetComponent<CircleCollider2D>();
        unit = unitSet;
        attackRange = unit.ShotRange;
        attackSpeed = unit.ShotSpeed;
    }
    public void SetUp(UnitSet unitSet)
    {
        unit = unitSet;
        attackRange = unit.ShotRange;
        attackSpeed = unit.ShotSpeed;
    }

    void Update()
    {

        attackRange = unit.ShotRange;
        attackSpeed = unit.ShotSpeed;


        if (Enemyes.Count >= 1)
        {
            FindTargetEnemy(); // 공격할 적 찾기
        }


        if (targetEnemy != null)
        {
            RotateTower(); // 적을 향해 타워 회전        
        }
    }

   
    void FindTargetEnemy()
    {
        colRange.radius = attackRange;                

        GameObject nearestEnemy = null;

        if (Enemyes[0]==null)
        {
            Debug.Log("aaaa");
            if (Enemyes.Count > 0)
            {
                Enemyes.RemoveAt(0);
            }            
            targetEnemy = null;
            return;
        }
        
        float distanceToEnemy = Vector3.Distance(transform.position, Enemyes[0].transform.position);

        if (distanceToEnemy <= colRange.radius+0.4f)
        {
            nearestEnemy = Enemyes[0].gameObject;
        }
        targetEnemy = nearestEnemy; // 가장 가까운 적을 추적 대상으로 설정

    }

    void RotateTower()
    {
        if (targetEnemy != null)
        {
            direction = targetEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (cor == null)
            {
                cor = StartCoroutine(Firetime());
            }
        }

    }

    IEnumerator Firetime()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            foreach (GameObject bullet in bulletList)
            {

                if (!bullet.activeInHierarchy) // 활성화되지 않은 총알을 찾아서 발사
                {
                    bullet.transform.position = firePoint.position;
                    bullet.transform.rotation = firePoint.rotation;
                    bullet.SetActive(true); // 총알 활성화하여 발사

                    Bullet bulletScript = bullet.GetComponent<Bullet>();
                    if (bulletScript != null && targetEnemy != null)
                    {
                        bulletScript.Seek(targetEnemy.transform); // 발사된 총알이 추적할 적 설정
                    }
                    break;
                }

            }
            yield return new WaitForSeconds(attackSpeed);
            //cor = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Enemyes.Add(collision.gameObject);            
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemyes.Remove(collision.gameObject);
        }
    }
}
